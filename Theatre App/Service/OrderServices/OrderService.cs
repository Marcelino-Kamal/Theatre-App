
using Theatre_App.DTO.CartDtos;
using Theatre_App.Models;
using Theatre_App.Repository.ItemsRepo;
using Theatre_App.Repository.OrderItemsRepo;
using Theatre_App.Repository.OrderRepo;

namespace Theatre_App.Service.OrderServices
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepo _ordersRepo;
        private readonly IOrderItemsRepo _orderItemsRepo;
     

        public OrderService(IOrderRepo ordersRepo,IOrderItemsRepo orderItems)
        {
            _ordersRepo = ordersRepo;
            _orderItemsRepo = orderItems;
           
        }

        public async Task<string> CreateOrder(CartAddDto dto)
        {
            //Validate Missing Yet ---------> To Do 
            var Order = new Orders
            {
                Id = Guid.NewGuid(),
                User_Id = dto.UserId,
                IsApproved = false,
                IsPaid = false,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate
            };
            await _ordersRepo.AddOrder(Order);

            var Oi = new OrderItem
            {
                ProductId = dto.Itemid,
                OrderId = Order.Id,
                Count = dto.Count,

            };

            await _orderItemsRepo.AddOrderWithItem(Oi);

            return "Succfully Added My Boi";

            
        }
    }
}

