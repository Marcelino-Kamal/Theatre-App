namespace Theatre_App.DTO.CartDtos
{
    public class CartAddDto
    {
        public Guid Itemid { get; set; }
        public Guid UserId { get; set; }
        public int Count { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
