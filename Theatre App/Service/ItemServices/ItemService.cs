using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Theatre_App.DTO.ItemDtos;
using Theatre_App.Models;
using Theatre_App.Repository.ItemsRepo;

namespace Theatre_App.Service.ItemServices
{
    public class ItemService(IItemsRepo itemsRepo, IWebHostEnvironment webHostEnvironment) : IItemService
    {
        private readonly IItemsRepo _itemsRepo = itemsRepo;
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

        public async Task<string> AddItem(ItemAddDto dto, IFormFile? file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            bool flag = false;
            if (file != null)
            {
                string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string ItemsPath = Path.Combine(wwwRootPath, @"assets\Items");
                using (var fileStream = new FileStream(Path.Combine(ItemsPath, filename), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                var ImgUrl = @"\assets\Items\" + filename;
                if (dto.Quantity > 0)
                {
                    flag= true;
                }
                var item = new Items
                {
                    Id = Guid.NewGuid(),
                    Name = dto.Name,
                    Description = dto.Description,
                    Catalogue_Id = dto.Catalogue_Id,
                    inStock = flag,
                    Price = dto.Price,
                    Quantity = dto.Quantity,
                    ImgUrl = ImgUrl,
                };
                await _itemsRepo.AddItem(item);
                return "Succefully Added";
            }

            return "something wrong";
             
           
        }


        public async Task<List<ItemResponseDto>> GetAllItems()
        {
            
            List<Items> items = await _itemsRepo.GetItems();
            Console.WriteLine(items);
            return items.Select(x => new ItemResponseDto
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name,
                InStock = x.inStock,
                Price = x.Price,
                Quantity = x.Quantity,
                ImgUrl = x.ImgUrl
            }).ToList();

        }

        public async Task<ItemResponseDto> GetitemByName(string Name)
        {
            var result  = await _itemsRepo.GetItemByName(Name);
            if(result == null)
            {
                return null;
            }

            return new ItemResponseDto
            {
                Id = result.Id,
                Name = result.Name,
                Quantity = result.Quantity,
                Price= result.Price,
                InStock = result.inStock,
                Description = result.Description,
                ImgUrl = result.ImgUrl
            };
           
        }

        public async Task<ItemResponseDto> GetitemById(Guid id)
        {
           var result = await _itemsRepo.GetItemById(id);
            if( result == null)
            {
                return null;
            }
            return new ItemResponseDto {
                Id = result.Id,
                Name = result.Name,
                Quantity = result.Quantity,
                Price= result.Price,
                Description = result.Description,
                InStock= result.inStock,
                ImgUrl = result.ImgUrl
            };
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
