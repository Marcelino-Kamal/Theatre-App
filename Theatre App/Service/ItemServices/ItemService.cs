using System.Threading.Tasks;
using Theatre_App.DTO.ItemDtos;
using Theatre_App.Models;
using Theatre_App.Repository.ItemsRepo;

namespace Theatre_App.Service.ItemServices
{
    public class ItemService : IItemService
    {
        private readonly IItemsRepo _itemsRepo;

        public ItemService(IItemsRepo itemsRepo)
        {
            _itemsRepo = itemsRepo;
        }

        public async Task<string> AddItem(ItemAddDto dto)
        {
            //TODO------Some Validation requried 
            var item = new Items {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                Catalogue_Id = dto.Catalogue_Id,
                inStock = dto.InStock,
                Price = dto.Price,
                Quantity = dto.Qunatity,
                ImgUrl = dto.ImgUrl
            };
            await _itemsRepo.AddItem(item);
            return "Succefully Added";
        }

        public async Task<List<Items>> GetAllItems()
        {
            return await _itemsRepo.GetItems();
        }

        public Items Getitem(string Name)
        {
            throw new NotImplementedException();
        }

        public async Task<string> RemoveItem(Guid id)
        {
            var item = await _itemsRepo.GetItemById(id);
            if (item == null)
            {
                return "Item doesn't exists!!";
            }
            var response = _itemsRepo.DeleteItem(item);
            if (response == null)
            {
                return "Error!! Something went Wrong";
            }
            return " Successfully Deleted!";
        }

        public Task<string> UpdateItem(ItemAddDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
