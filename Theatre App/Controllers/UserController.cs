using Microsoft.AspNetCore.Mvc;

namespace Theatre_App.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
