using TheatreApp.Models;
namespace TheatreApp.Repositories
{
    public interface IUserRepo
    {
        bool NumberExists(string phoneNumber);
        UserModel GetByNumber(string phoneNumber);
        void AddUser(UserModel user);
    }
}