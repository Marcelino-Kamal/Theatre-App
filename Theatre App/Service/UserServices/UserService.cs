using Theatre_App.DTO.UserDtos;
using Theatre_App.Repository.UserRepo;

namespace Theatre_App.Service.UserServices
{
    public class UserService : IUserService
    {
        private readonly  IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<UserResponeDto> GetUserById(Guid id)
        {
           var User = await _userRepo.GetById(id);
            if (User == null) {

                return null;
            }
            return new UserResponeDto
            {
                Name = User.Name,
                PhoneNumber = User.PhoneNumber,
            };

        }

        public Task<string> UpdateUser(UserUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
