using Theatre_App.Models;

namespace Theatre_App.Repository.UserRepo
{
    public interface IUserRepo
    {
        List<Users> GetUsers();
        Users GetByName(string name);
        void Update(Users user);
        void Delete(Users user);

    }
}
