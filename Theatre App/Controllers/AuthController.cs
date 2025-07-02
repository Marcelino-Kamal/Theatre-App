using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Theatre_App.DTO.UserDtos;
using Theatre_App.Service.AuthServices;

namespace Theatre_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
       private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] UserSignUpDto dto) 
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _authService.Register(dto);
            if (result == "Phone Number exists" || result == "Name cannot be empty or whitespace")
                return BadRequest(new { message = result });

            return Ok(new { message = result });
        }
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] UserLoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.Login(dto);
            if (result != "Login is Succefull")
                return BadRequest(new { message = result });

            return Ok(new { message = result });
        }
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            _authService.Logout();
            return Ok(new {message = "logged out!"});
        }



    }
}
