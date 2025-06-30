using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Getitems() { 
            var items = _itemService.GetAllItems();
            return Ok(items);
        }

    }
}
