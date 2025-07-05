using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Theatre_App.DTO.CartDtos;
using Theatre_App.DTO.OrderDtos;
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
        [Authorize]
        [HttpGet("myorder")]
        public async Task<IActionResult> GetMyOrder() {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return Unauthorized("User ID not found in token.");

            var result = await _orderService.GetUserOrder(Guid.Parse(userId));


            if (result == null)
                return NotFound(new { message = "user's order not found" });
            return Ok(result);
        }
        [HttpPut("updateorder")]
        public async Task<IActionResult> updateOrders(OrderUpdateDto dto)
        {
            var res = await _orderService.UpdateOrder(dto);

            if(res != "Successfully updateds")
            {
                return BadRequest(new {message = res});
            }
            return Ok(res);
        }
    }
}
