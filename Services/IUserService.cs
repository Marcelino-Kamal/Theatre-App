using TheatreApp.DTO;
namespace TheatreApp.Services
{
    public interface IUserService
    {
        TokenDTO Register(UserDTO dto, out string errorMessage);
        TokenDTO Login(UserDTO dto, out string errorMessage);
    }
}