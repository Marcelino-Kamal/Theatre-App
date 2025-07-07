
using Theatre_App.DTO.UserDtos;
using Theatre_App.Helpers;
using Theatre_App.Models;
using Theatre_App.Repository.UserRepo;

namespace Theatre_App.Service.AuthServices
{
    public class AuthService(IUserRepo userRepo, JwtHelper jwtHelper, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment) : IAuthService
    {
        private readonly IUserRepo _userRepo = userRepo;
        private readonly JwtHelper _jwtHelper = jwtHelper;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;


        public async Task<String> Register(UserSignUpDto userdto, IFormFile file) {
            string wwwRootPath = _webHostEnvironment.WebRootPath;

            if (file == null)  return "National ID is missing";

            string filename = userdto.Name + Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string ItemsPath = Path.Combine(wwwRootPath, @"assets\NationalId");
            using (var fileStream = new FileStream(Path.Combine(ItemsPath, filename), FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            var ImgUrl = @"\assets\NationalId\" + filename;
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
                Password = hashed,
                NationalId = ImgUrl

            };
            await _userRepo.AddUser(user);
            return "Succefully added!!";

        }

        public async Task<string> Login(UserLoginDto userdto)
        {
            var user = await _userRepo.GetByPhoneNumber(userdto.PhoneNumber);
            if (user == null)
            {
                return "User Not Found!!";
            }
            if(user.isActive == false)
            {
                return "Account isn't Activated contact Admin";
            }

            var result = PasswordHelper.VerifyPassword(user.Password, userdto.Password);
            if (!result)
            {
                return "Invalid Password";
            }

            try
            {
                var jwtResult = JwtHelper.GenerateToken(user);

                _httpContextAccessor.HttpContext.Response.Cookies.Append("AuthToken", jwtResult.Token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = jwtResult.Expiry
                });

                return "Login is Succefull";
            }
            catch (Exception ex)
            {
                Console.WriteLine("JWT Error: " + ex.Message);
                return "JWT generation failed: " + ex.Message;
            }

            
        }

        public void Logout()
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete("AuthToken");
        }
    }
}
