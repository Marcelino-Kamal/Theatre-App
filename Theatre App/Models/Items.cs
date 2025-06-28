using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Theatre_App.Models
{
    public class Items
    {
        [Key]
        public Guid Id { get; set; } 

        [Required]
        public string Name { get; set; }

        [Required,MaybeNull]
        public string Description { get; set; }

        [Required]
        public int Quantity { get; set; } = 0;

        [Required]
        public bool inStock { get; set; } = false;

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required]
        public int Catalogue_Id { get; set; }

        [MaybeNull]
        public string ImgUrl { get; set; }

        [ForeignKey("Catalogue_Id")]
        public Catalogue Catalogue { get; set; }

 





    }
}
