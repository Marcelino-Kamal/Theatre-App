

using Theatre_App.DTO.CartDtos;

namespace Theatre_App.Service.OrderServices
{
    public interface IOrderService
    {
        Task<string> CreateOrder(CartAddDto dto);
    }
}
