using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Theatre_App.DTO.CartDtos;
using Theatre_App.Service.OrderServices;

namespace Theatre_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController(IOrderService orderService) : Controller
    {
        private readonly IOrderService _orderService = orderService;

        [HttpPost("addorder")]
        public async Task<IActionResult> addOrder([FromForm]CartAddDto dto)
        {
            var result = await _orderService.CreateOrder(dto);
            if (result != "Succfully Added My Boi") {

                return BadRequest(new { message = result });
                
            }
            return Ok(new { message = result });
        }
    }
}
