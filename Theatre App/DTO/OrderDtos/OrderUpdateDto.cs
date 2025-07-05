namespace Theatre_App.DTO.OrderDtos
{
    public class OrderUpdateDto
    {
        public Guid orderId { get; set; }
        public bool IsApproved { get; set; }
        public bool IsPaid { get; set; }
    }
}
