namespace Theatre_App.DTO.ItemDtos
{
    public class ItemResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = "";
        public bool InStock {  get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImgUrl { get; set; }

    }
}
