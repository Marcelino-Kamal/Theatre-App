using System.ComponentModel.DataAnnotations;

namespace Theatre_App.DTO
{
    public class UserLoginDto
    {
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
