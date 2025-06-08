using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theatre_App.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Orders Orders { get; set; }

        [Required]
        public Guid ItemId { get; set; }

        [ForeignKey("ItemId")]
        public Items Items { get; set; }

        public int Quantity { get; set; }
    }
}
