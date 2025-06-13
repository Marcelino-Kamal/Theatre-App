using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class UserModel
{
    public string fullName { get; set; }

    [Key]
    public string phoneNumber { get; set; }
    public string password { get; set; }
}
}