using Theatre_App.Data;
using Theatre_App.Models;

namespace Theatre_App.Repository.UserRepo
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext _context;

        public UserRepo(ApplicationDbContext _context) {
            
            this._context = _context;
        
        }

        public void Delete(Users user)
        {
            throw new NotImplementedException();
        }

        public Users GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Users> GetUsers()
        {
            throw new NotImplementedException();
        }

        public void Update(Users user)
        {
            throw new NotImplementedException();
        }
    }
}
