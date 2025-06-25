using Microsoft.AspNetCore.Mvc;
using TheatreApp.DTO;
using TheatreApp.Helpers;
using TheatreApp.Services;
using Microsoft.AspNetCore.Authorization;


namespace TheatreApp.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        //shows sign up view
        [HttpGet]
        public IActionResult Signup() => View();
        //throws error messages for sign up
        [HttpPost]
        public IActionResult Signup(UserDTO dto)
        {
            var auth = _userService.Register(dto, out string erroMessage);
            if (auth == null)
            {
                ViewBag.ErrorMessage = erroMessage;
                return View();
            }

            Response.Cookies.Append("jwt", auth.Token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = DateTime.UtcNow.AddHours(1)
            });

            return RedirectToAction("Index", "Items");
        }

        //shows login view
        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        //throws error message for login
        public IActionResult Login(UserDTO dto)
        {
            var auth = _userService.Login(dto, out string errorMessage);
            
            if (auth == null)
            {
                ViewBag.ErrorMessage = errorMessage;
                return View();
            }

            Response.Cookies.Append("jwt", auth.Token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = DateTime.UtcNow.AddHours(1)
            });

            return RedirectToAction("Index", "Items");
        }

    }
}