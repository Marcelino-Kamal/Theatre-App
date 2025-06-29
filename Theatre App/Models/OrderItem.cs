using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theatre_App.Models
{
    [PrimaryKey(nameof(OrderId), nameof(ProductId))]
    public class OrderItem
    {
        public Guid ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Items Item { get; set; }

        [Required]
        public int Count { get; set; }

        public Guid OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Orders Order { get; set; }
    }
}
