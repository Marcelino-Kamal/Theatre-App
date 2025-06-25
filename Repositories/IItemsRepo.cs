using TheatreApp.Models;
namespace TheatreApp.Repositories
{
    public interface IItemsRepo
    {
        List<Item> GetAll();
        void Add(Item item);
    }
}
