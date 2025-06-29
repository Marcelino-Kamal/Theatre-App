namespace Theatre_App.DTO.ItemDtos
{
    public class ItemAddDto
    {
        public string Name { get; set; }
        public string Description { get; set; } = "";
        public bool InStock { get; set; }
        public decimal Price { get; set; }
        public int Qunatity { get; set; }
        public int Catalogue_Id { get; set; }
        public string ImgUrl { get; set; }

    }
}
