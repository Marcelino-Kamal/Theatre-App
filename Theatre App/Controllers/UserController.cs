using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Theatre_App.Service.UserServices;

namespace Theatre_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [Authorize]
        [HttpGet("getuser")]
        public async Task<IActionResult> GetUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized("User ID not found in token.");

            var user = await _userService.GetUserById(Guid.Parse(userId)); 

            if (user == null)
                return NotFound("User not found.");

            return Ok(user);
        }
        [Authorize(Roles = "admin")]
        [HttpGet("getusers")]
        public async Task<IActionResult> GetAllUsers() {
            var result = await _userService.GetAllUsers();
            if(result == null)
            {
                return NotFound("Users not found.");
            }
            return Ok(result);
           
        }
    }
}
