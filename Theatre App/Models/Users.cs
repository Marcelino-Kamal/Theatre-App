using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theatre_App.Models
{
    [Index(nameof(PhoneNumber), IsUnique = true)]
    public class Users
    {
        [Key]
        public Guid Id { get; set; } 

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = "0000";

        [Required]
        [MinLength(6,ErrorMessage = "Password must be longer than 6 Characters")]
        public string Password {  get; set; }

        public int RoleID { get; set; } = 2;

        [ForeignKey("RoleID")]
        public Roles Role { get; set; }

        



    }
}
