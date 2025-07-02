using Theatre_App.Data;
using Theatre_App.Models;

namespace Theatre_App.Repository.OrderItemsRepo
{
    public class OrderItemsRepo : IOrderItemsRepo
    {
        private readonly ApplicationDbContext _context;

        public OrderItemsRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddOrderWithItem(OrderItem orderItem)
        {
            await _context.AddAsync(orderItem);
            await _context.SaveChangesAsync();
        }
    }
}
