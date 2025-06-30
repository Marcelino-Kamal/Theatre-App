using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Theatre_App.Data;
using Theatre_App.Models;

namespace Theatre_App.Repository.ItemsRepo
{
    public class ItemsRepo : IItemsRepo
    {
        private readonly ApplicationDbContext _context;

        public ItemsRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddItem(Items item)
        {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItem(Items item)
        {
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Items> GetItemByName(string name)
        {
            return await _context.Items.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
        }

        public async Task<List<Items>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task UpdateItem(Items item)
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Items> GetItemById(Guid id)
        {
            return await _context.Items.FindAsync(id);

        }
    }
}
