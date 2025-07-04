using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theatre_App.Models
{
    [PrimaryKey(nameof(OrderId), nameof(ItemId))]
    public class OrderItem
    {
        public Guid ItemId { get; set; }

        [ForeignKey("ItemId")]
        public Items Item { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public Guid OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Orders Order { get; set; }
    }
}
