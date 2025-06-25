using TheatreApp.Repositories;
using TheatreApp.Models;
using TheatreApp.DTO;
namespace TheatreApp.Services
{
    public class ItemsService : IItemsService
    {
        private readonly IItemsRepo _repo;

        public ItemsService(IItemsRepo repo)
        {
            _repo = repo;
        }

        public List<Item> GetAllItems()
        {
            return _repo.GetAll();
        }

        public void AddItem(ItemsDTO dto)
        {
            var item = new Item
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                ImageUrl = dto.ImageUrl
            };

            _repo.Add(item);
        }
    }
}
