using Microsoft.EntityFrameworkCore;
using Theatre_App.Data;
using Theatre_App.Models;

namespace Theatre_App.Repository.OrderRepo
{
    public class OrderRepo : IOrderRepo
    {

        private readonly ApplicationDbContext _context;

        public OrderRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddOrder(Orders order)
        {
            await _context.AddAsync(order);
            await _context.SaveChangesAsync();
        }
    }
}

