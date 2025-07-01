using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Theatre_App.DTO.ItemDtos;
using Theatre_App.Service.ItemServices;

namespace Theatre_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("listItems")]
        public async Task<IActionResult> Getitems() { 
            var items = await _itemService.GetAllItems();
            return Ok(items);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetitemAsync([FromQuery] string name) {

            var item = await _itemService.Getitem(name);
            return Ok(item);
        }
        [HttpPost("additem")]
        public async Task<IActionResult> AddItems([FromForm]ItemAddDto dto)
        {
           var res = await _itemService.AddItem(dto, dto.file);
            return Ok(new { message = res } );
        }

    }
}
