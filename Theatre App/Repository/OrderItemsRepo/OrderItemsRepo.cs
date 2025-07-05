using Microsoft.EntityFrameworkCore;
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

        public async Task<List<OrderItem>> GetAllOrders()
        {
            return await _context.OrderItems.Include(x=>x.Order).ThenInclude(o=>o.Users).Include(z=>z.Item).ToListAsync();
        }

        public async Task<List<OrderItem>> GetOrdersByUserId(Guid id)
        {
            return await _context.OrderItems.Include(x=>x.Order).ThenInclude(o=>o.Users).Include(z=>z.Item).Where(x=>x.Order.User_Id == id).ToListAsync();
        }
    }
}
