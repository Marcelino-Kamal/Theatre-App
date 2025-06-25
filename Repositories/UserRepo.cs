using TheatreApp.Data;
using TheatreApp.Models;
namespace TheatreApp.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly AccountsContext _context;

        public UserRepo(AccountsContext context)
        {
            _context = context;
        }
        //checks if number in db
        public bool NumberExists(string phoneNumber)
        {
            return _context.Users.Any(u => u.phoneNumber == phoneNumber);
        }
        //grabs user by number
        public UserModel GetByNumber(string phoneNumber)
        {
            return _context.Users.FirstOrDefault(u => u.phoneNumber == phoneNumber);
        }
        //adds new user
        public void AddUser(UserModel user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}