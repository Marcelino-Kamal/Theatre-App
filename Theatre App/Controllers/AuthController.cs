using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Theatre_App.DTO;
using Theatre_App.Service.AuthServices;

namespace Theatre_App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
       private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromForm] UserSignUpDto dto) 
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _authService.Register(dto);
            return Ok(result);
        }
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromForm] UserLoginDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _authService.Login(dto);

            return Ok(result);
        }



    }
}
