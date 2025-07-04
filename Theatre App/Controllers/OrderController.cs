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
        public async Task<IActionResult> AddOrder([FromBody]CartAddDto dto)
        {
            var result = await _orderService.CreateOrder(dto);
            if (result != "Successfully Added") {

                return BadRequest(new { message = result });
                
            }
            return Ok(new { message = result });
        }
        [HttpGet("getorders")]
        public async Task<IActionResult> GetOrders()
        {
            var result = await _orderService.GetAllOrders();
            if(result == null)
            {
                return NotFound(new {message = "No Orders Found atm"});
            }
            return Ok(result);
        }
    }
}
