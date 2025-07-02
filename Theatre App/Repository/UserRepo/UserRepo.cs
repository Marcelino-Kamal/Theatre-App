using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Theatre_App.Data;
using Theatre_App.Models;

namespace Theatre_App.Repository.UserRepo
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext _context;

        public UserRepo(ApplicationDbContext _context) { this._context = _context; }

        public async Task DeleteUser(Users user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<Users> GetByName(string name) { return await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(x => x.Name == name); }

        public async Task<Users> GetByPhoneNumber(string phoneNumber) { return await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber); }



        public async Task<List<Users>> GetUsers() { return await _context.Users.ToListAsync(); }

        public async Task UpdateUser(Users user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task AddUser(Users user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

        }

        public async Task<Users> GetById(Guid id)
        {
            return await _context.Users.Include(x => x.Role).FirstOrDefaultAsync(z => z.Id == id);
        }
    }
}
