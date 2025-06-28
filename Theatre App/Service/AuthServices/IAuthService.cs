using Theatre_App.DTO;

namespace Theatre_App.Service.AuthServices
{
    public interface IAuthService
    {
        Task<String> Register(UserSignUpDto userdto);
        Task<String> Login(UserLoginDto userdto);
    }
}
