using Theatre_App.Models;

namespace Theatre_App.Repository.OrderRepo
{
    public interface IOrderRepo
    {
        Task AddOrder(Orders order);
        
    }
}
