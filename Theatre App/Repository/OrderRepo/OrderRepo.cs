using Microsoft.EntityFrameworkCore;
using Theatre_App.Data;
using Theatre_App.Models;

namespace Theatre_App.Repository.OrderRepo
{
    public class OrderRepo(ApplicationDbContext context) : IOrderRepo
    {

        private readonly ApplicationDbContext _context = context;

        public async Task AddOrder(Orders order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public Task DeleteOrder(Orders order)
        {
            throw new NotImplementedException();
        }

        public async Task<Orders?> GetOrder(Guid orderId)
        {
            return await _context.Orders.Include(x => x.Users).FirstOrDefaultAsync(z=>z.Id==orderId);
        }

        public async Task UpdateOrder(Orders order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}

