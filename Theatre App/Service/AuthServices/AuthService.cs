using Theatre_App.DTO;
using Theatre_App.Helpers;
using Theatre_App.Models;
using Theatre_App.Repository.UserRepo;

namespace Theatre_App.Service.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepo _userRepo;


        public AuthService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<String> Register(UserSignUpDto userdto) {

            string FName = userdto.Name.Trim();
            string Phone = userdto.PhoneNumber.Trim();

            var exists = await _userRepo.GetByPhoneNumber(Phone);
            if (exists != null) 
                return "Phone Number exists";
            if (string.IsNullOrWhiteSpace(FName))
                return "Name cannot be empty or whitespace";

            string hashed = PasswordHelper.HashPassword(userdto.Password);
            var user = new Users
            {
                Id = Guid.NewGuid(),
                Name = FName,
                PhoneNumber = Phone,
                Password = hashed
            };
            await _userRepo.AddUser(user);
            return "Succefully added";
        }

        public async Task<String> Login(UserLoginDto userdto) {

            var user = await _userRepo.GetByPhoneNumber(userdto.PhoneNumber);
            if (user == null) {
                return "User Not Found!!";
            }
            var result = PasswordHelper.VerifyPassword(user.Password, userdto.Password);
            if (!result)
            {
                return "Invalid Password";
            }
            //jwt helper implementation

            return "Login is Succefull";
        }
         
        

    }
}
