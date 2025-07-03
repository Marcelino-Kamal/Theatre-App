using Theatre_App.Models;

namespace Theatre_App.Repository.OrderItemsRepo
{
    public interface IOrderItemsRepo
    {
        Task AddOrderWithItem(OrderItem orderItem);
        Task<List<OrderItem>> GetAllOrders();
    }
}
