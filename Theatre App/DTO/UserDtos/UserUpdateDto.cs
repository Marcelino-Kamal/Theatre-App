using System.ComponentModel.DataAnnotations;

namespace Theatre_App.DTO.UserDtos
{
    public class UserUpdateDto
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }

        

        
    }
}
