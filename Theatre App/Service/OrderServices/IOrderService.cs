

using Theatre_App.DTO.CartDtos;
using Theatre_App.DTO.OrderDtos;

namespace Theatre_App.Service.OrderServices
{
    public interface IOrderService
    {
        Task<string> CreateOrder(CartAddDto dto);
        Task<List<OrderItemResponseDto>> GetAllOrders();
    }
}
