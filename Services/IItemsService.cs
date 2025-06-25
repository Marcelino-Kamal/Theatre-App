using TheatreApp.Models;
using TheatreApp.DTO;
namespace TheatreApp.Services { 

    public interface IItemsService
    {
        List<Item> GetAllItems();
        void AddItem(ItemsDTO dto);
    }
}
