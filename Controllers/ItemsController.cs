using Microsoft.AspNetCore.Mvc;
using TheatreApp.Services;
using TheatreApp.DTO;
namespace TheatreApp.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemsService _service;

        public ItemsController(IItemsService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var items = _service.GetAllItems();
            return View(items);
        }

        
        //adds new item to items db
        [HttpPost]
        public IActionResult Add(ItemsDTO dto)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            _service.AddItem(dto);
            return RedirectToAction("Index");
        }

        //logsout and deletes token
        [HttpPost]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return RedirectToAction("Login", "Account");
        }
    }
}
