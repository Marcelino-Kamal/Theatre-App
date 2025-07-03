using Theatre_App.DTO.UserDtos;
using Theatre_App.Models;
using Theatre_App.Repository.UserRepo;

namespace Theatre_App.Service.UserServices
{
    public class UserService(IUserRepo userRepo) : IUserService
    {
        private readonly  IUserRepo _userRepo = userRepo;

        public async Task<List<UserResponeDto>> GetAllUsers()
        {
            List<Users> users = await _userRepo.GetUsers();

            return users.Select(x=> new UserResponeDto {
                Id = x.Id,
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
                Role = x.Role.Name
            }).ToList();

        }

        public async Task<UserResponeDto> GetUserById(Guid id)
        {
           var User = await _userRepo.GetById(id);
            if (User == null) {

                return null;
            }
            return new UserResponeDto
            {
                Id = User.Id,
                Name = User.Name,
                PhoneNumber = User.PhoneNumber,
                Role = User.Role.Name
            };

        }

        public Task<string> UpdateUser(UserUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
