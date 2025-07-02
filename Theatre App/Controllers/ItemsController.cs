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

            var item = await _itemService.GetitemByName(name);
            return Ok(item);
        }
        [HttpPost("additem")]
        public async Task<IActionResult> AddItems([FromForm]ItemAddDto dto)
        {
           var res = await _itemService.AddItem(dto, dto.file);
            return Ok(new { message = res } );
        }
        [HttpGet("getitem/{id}")]
        public async Task<IActionResult> GetItem(Guid id)
        {
            var item = await _itemService.GetitemById(id);
            if (item == null)
            {
                return NotFound(new {Message = "This item is Missing"});

            }
            return Ok(item);
        }
    }
}
