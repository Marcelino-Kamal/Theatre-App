using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theatre_App.Models
{
    public class Orders
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid User_Id { get; set; }

        [Required]
        public bool IsApproved { get; set; } = false;
        [Required]
        public bool IsPaid { get; set; } = false;

        [ForeignKey("User_Id")]
        public Users Users { get; set; }

        [NotMapped]
        public int Duration => (EndDate - StartDate).Days;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }



    }
}
