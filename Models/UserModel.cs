using System.ComponentModel.DataAnnotations;

namespace TheatreApp.Models
{
    public class UserModel
{
    public string fullName { get; set; }

    [Key]
    public string phoneNumber { get; set; }
    public string password { get; set; }
}
}