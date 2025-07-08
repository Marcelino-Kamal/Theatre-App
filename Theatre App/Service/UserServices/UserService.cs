using Theatre_App.DTO.UserDtos;
using Theatre_App.Models;
using Theatre_App.Repository.UserRepo;

namespace Theatre_App.Service.UserServices
{
    public class UserService(IUserRepo userRepo) : IUserService
    {
        private readonly  IUserRepo _userRepo = userRepo;

        public async Task<string> ApproveUser(UserStatusDto dto)
        {
            Users u = await _userRepo.GetById(dto.Id);
            if (u == null) {

                return "User Not Found";
            
            }
            u.isActive = dto.IsActive;

            await _userRepo.UpdateUser(u);
            return "Successfully Approved";
           
        }

        public async Task<List<UserAdminResponseDto>> GetAllUsers()
        {
            List<Users> users = await _userRepo.GetUsers();

            return users.Select(x=> new UserAdminResponseDto
            {
                Id = x.Id,
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
                Role = x.Role.Name,
                NationalId = x.NationalId,
                isApproved = x.isActive,
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

        public async Task<string> UpdateUser(UserUpdateDto dto)
        {
           
            Users u = await _userRepo.GetById(dto.Id);
            if (u == null) {

                return "User Not Found";
            }
            bool inUse = await _userRepo.PhoneNumberInUse(dto.PhoneNumber, dto.Id);
            if(inUse) {
                return " Phone number is already in user";
            }
            u.Name = dto.Name;
            u.PhoneNumber = dto.PhoneNumber;

            await _userRepo.UpdateUser(u);

            return "Successfully Updated!";


        }


    }
}
