

using Theatre_App.DTO.CartDtos;
using Theatre_App.DTO.OrderDtos;

namespace Theatre_App.Service.OrderServices
{
    public interface IOrderService
    {
        Task<string> CreateOrder(CartAddDto dto);
        Task<List<OrderItemResponseDto>> GetAllOrders();
        Task<List<OrderItemResponseDto>> GetUserOrder(Guid userId);
        Task<string> UpdateOrder(OrderUpdateDto dto);
    }
}
