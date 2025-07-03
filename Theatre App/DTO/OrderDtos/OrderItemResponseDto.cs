namespace Theatre_App.DTO.OrderDtos
{
    public class OrderItemResponseDto
    {
        public Guid OrderId { get; set; }
        public string itemName { get; set; }
        public string UserName { get; set; }
        public bool IsApproved { get; set; }
        public bool IsPaid { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Abona_Approved { get; set; }
        public string Payment { get; set; }
        public int Count { get; set; }
    }
}
