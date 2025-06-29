using Theatre_App.DTO.ItemDtos;
using Theatre_App.Models;

namespace Theatre_App.Service.ItemServices
{
    public interface IItemService
    {
        Task<string> AddItem(ItemAddDto dto);
        Task<string> RemoveItem(Guid id);
        Task<string> UpdateItem(ItemAddDto dto);
        Task<List<Items>> GetAllItems();
        Task<Items> Getitem(string Name);
    }
}
