using Theatre_App.DTO.ItemDtos;


namespace Theatre_App.Service.ItemServices
{
    public interface IItemService
    {
        Task<string> AddItem(ItemAddDto dto, IFormFile? file);
        Task<string> RemoveItem(Guid id);
        Task<string> UpdateItem(ItemAddDto dto);
        Task<List<ItemResponseDto>> GetAllItems();
        Task<ItemResponseDto> GetitemByName(string Name);
        Task<ItemResponseDto> GetitemById(Guid id);
    }
}
