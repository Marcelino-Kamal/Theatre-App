namespace Theatre_App.DTO.CartDtos
{
    public class CartItemDto
    {
        public Guid ItemId { get; set; }
        public int Count { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
