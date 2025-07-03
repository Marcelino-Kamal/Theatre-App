
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
            var item = await _itemsRepo.GetItemById(dto.Itemid);
            if (dto.Count > item.Quantity) {
                return "Cannot Add Order" +
                    " there is :" + item.Quantity + " in stock";

            }
            if (dto.StartDate >= dto.EndDate){
                return "StartDate Must be smaller than EndDate";
            }

            var Order = new Orders{
                Id = Guid.NewGuid(),
                User_Id = dto.UserId,
                IsApproved = false,
                IsPaid = false,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Abona_approved = "No",
                Payment ="No"
            };
            await _ordersRepo.AddOrder(Order);

            var Oi = new OrderItem  {
                ItemId = dto.Itemid,
                OrderId = Order.Id,
                Count = dto.Count,

            };
            await _orderItemsRepo.AddOrderWithItem(Oi);
            return "Succfully Added";
        }
        public async Task<List<OrderItemResponseDto>> GetAllOrders()
        {

            List<OrderItem> orderItems = await _orderItemsRepo.GetAllOrders();
            Console.WriteLine(orderItems);
            return orderItems.Select(x => new OrderItemResponseDto
            {
                OrderId = x.OrderId,
                itemName = x.Item.Name,
                UserName = x.Order.Users.Name,
                IsApproved = x.Order.IsApproved,
                IsPaid = x.Order.IsPaid,
                StartDate = x.Order.StartDate,
                EndDate = x.Order.EndDate,
                Abona_Approved = x.Order.Abona_approved,
                Payment = x.Order.Payment
            }).ToList();
        }
    }
}

