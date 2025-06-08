using Microsoft.AspNetCore.Mvc;

namespace Theatre_App.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
