using Theatre_App.Models;

namespace Theatre_App.Repository.UserRepo
{
    public interface IUserRepo
    {
        Task<List<Users>> GetUsers();
        Task<Users> GetByName(string name);
        Task UpdateUser(Users user);
        Task DeleteUser(Users user);
        Task AddUser(Users user);
        Task<Users> GetByPhoneNumber(string phoneNumber);
        Task<Users> GetById(Guid id);
        Task<bool> PhoneNumberInUse(string phoneNumber,Guid id);
        

    }
}
