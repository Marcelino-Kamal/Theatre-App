namespace Theatre_App.DTO.CartDtos
{
    public class CartAddDto
    {
        public List<CartItemDto> Items { get; set; }
        public Guid UserId { get; set; }

  

    }
}
