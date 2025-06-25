using Microsoft.EntityFrameworkCore;
using TheatreApp.Models;
namespace TheatreApp.Data
{
    public class AccountsContext : DbContext
    {
        public AccountsContext(DbContextOptions<AccountsContext> options)
            : base(options)
        {
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}