using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theatre_App.Models
{
    public class Orders
    {
        [Key]
        public Guid Id {  get; set; } 

        [Required]
        public Guid User_Id { get; set; }

        [Required]
        public bool IsApproved { get; set; } = false;
        [Required]
        public bool IsPaid { get; set; } = false;

        [ForeignKey("User_Id")]
        public Users Users { get; set; }

        public List<OrderItem> Contents { get; set; }


    }
}
