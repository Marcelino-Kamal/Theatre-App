using System.ComponentModel.DataAnnotations;

namespace Theatre_App.DTO.UserDtos
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
