using Theatre_App.Models;

namespace Theatre_App.Repository.ItemsRepo
{
    public interface IItemsRepo
    {
        Task<List<Items>> GetItems();
        Task AddItem(Items item);
        Task UpdateItem(Items item);
        Task DeleteItem(Items item);
        Task<Items> GetItemByName(string name);
        Task<Items> GetItemById(Guid id);


    }
}
