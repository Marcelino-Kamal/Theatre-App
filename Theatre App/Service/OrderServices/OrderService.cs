
using Theatre_App.DTO.CartDtos;
using Theatre_App.DTO.OrderDtos;
using Theatre_App.Models;
using Theatre_App.Repository.ItemsRepo;
using Theatre_App.Repository.OrderItemsRepo;
using Theatre_App.Repository.OrderRepo;

namespace Theatre_App.Service.OrderServices
{
    public class OrderService(IOrderRepo ordersRepo, IOrderItemsRepo orderItemsRepo, IItemsRepo itemsRepo) : IOrderService
    {

        private readonly IOrderRepo _ordersRepo = ordersRepo;
        private readonly IOrderItemsRepo _orderItemsRepo = orderItemsRepo;
        private readonly IItemsRepo _itemsRepo = itemsRepo;

        public async Task<string> CreateOrder(CartAddDto dto)
        {
    
            foreach (var cartItem in dto.Items)
            {
                if (cartItem.StartDate >= cartItem.EndDate)
                {
                    return "StartDate must be earlier than EndDate.";
                }
                var difference = (cartItem.EndDate - cartItem.StartDate).TotalDays;
                if (difference > 7)
                {
                    return "Can't rent items more than 7 days";
                }
                var item = await _itemsRepo.GetItemById(cartItem.ItemId);
                if (item == null)
                {
                    return $"Item with ID {cartItem.ItemId} not found.";
                }

                if (cartItem.Count > item.Quantity)
                {
                    return $"Cannot add order: Only {item.Quantity} units in stock for item {item.Name}.";
                }
            }

        
            var order = new Orders
            {
                Id = Guid.NewGuid(),
                User_Id = dto.UserId,
                IsApproved = false,
                IsPaid = false,
                Abona_approved = "No",
                Payment = "No"
            };
            await _ordersRepo.AddOrder(order);

      
            foreach (var cartItem in dto.Items)
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ItemId = cartItem.ItemId,
                    Count = cartItem.Count,
                    StartDate = cartItem.StartDate,
                    EndDate = cartItem.EndDate
                    
                };

                await _orderItemsRepo.AddOrderWithItem(orderItem);


                 /*
                 var item = await _itemsRepo.GetItemById(cartItem.ItemId);
                 item.Quantity -= cartItem.Count;
                 item.inStock = item.Quantity > 0;
                 await _itemsRepo.UpdateItem(item);
                 */
            }

            return "Successfully Added";
        }

        public async Task<List<OrderItemResponseDto>> GetAllOrders()
        {

            List<OrderItem> orderItems = await _orderItemsRepo.GetAllOrders();

            return orderItems.Select(x => new OrderItemResponseDto
            {
                OrderId = x.OrderId,
                itemName = x.Item.Name,
                UserName = x.Order.Users.Name,
                Count = x.Count,
                IsApproved = x.Order.IsApproved,
                IsPaid = x.Order.IsPaid,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Abona_Approved = x.Order.Abona_approved,
                Payment = x.Order.Payment
            }).ToList();
        }

        public async Task<List<OrderItemResponseDto>> GetUserOrder(Guid userId)
        {
            List<OrderItem> oi = await _orderItemsRepo.GetOrdersByUserId(userId);

            return oi.Select(x => new OrderItemResponseDto
            {
                OrderId = x.OrderId,
                itemName = x.Item.Name,
                UserName = x.Order.Users.Name,
                Count = x.Count,
                IsApproved = x.Order.IsApproved,
                IsPaid = x.Order.IsPaid,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Abona_Approved = x.Order.Abona_approved,
                Payment = x.Order.Payment

            }).ToList();
        }

        public async Task<string> UpdateOrder(OrderUpdateDto dto)
        {
          Orders o = await _ordersRepo.GetOrder(dto.orderId);

            if (o == null) {
                return "Not Found";
            }
            o.IsApproved = dto.IsApproved;
            o.IsPaid = dto.IsPaid;
           
            await _ordersRepo.UpdateOrder(o);

            return "Successfully updateds";

            
        }
    }
}

