namespace Theatre_App.DTO.UserDtos
{
    public class UserAdminResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public string NationalId { get; set; }
        public bool isApproved { get; set; } 
    }
}
