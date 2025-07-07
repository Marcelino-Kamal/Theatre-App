using System.ComponentModel.DataAnnotations;

namespace Theatre_App.DTO.UserDtos
{
    public class UserSignUpDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string Confirm {  get; set; }

        [Required]
        public IFormFile NationalId { get; set; }
    }
}
