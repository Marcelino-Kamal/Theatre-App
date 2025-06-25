using TheatreApp.Data;
using TheatreApp.Models;
namespace TheatreApp.Repositories
{
    public class ItemsRepo : IItemsRepo
    {
        private readonly AccountsContext _context;

        public ItemsRepo(AccountsContext context)
        {
            _context = context;
        }

        public List<Item> GetAll()
        {
            return _context.Items.ToList();
        }

        public void Add(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }
    }
}
