using Theatre_App.DTO.UserDtos;

namespace Theatre_App.Service.AuthServices
{
    public interface IAuthService
    {
        Task<String> Register(UserSignUpDto userdto , IFormFile file);
        Task<String> Login(UserLoginDto userdto);
        void Logout();
    }
}
