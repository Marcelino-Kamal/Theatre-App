
using Theatre_App.DTO.CartDtos;
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
                EndDate = dto.EndDate
            };
            await _ordersRepo.AddOrder(Order);

            var Oi = new OrderItem  {
                ProductId = dto.Itemid,
                OrderId = Order.Id,
                Count = dto.Count,

            };
            await _orderItemsRepo.AddOrderWithItem(Oi);
            return "Succfully Added";
        }
    }
}

