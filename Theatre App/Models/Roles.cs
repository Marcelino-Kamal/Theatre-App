using System.ComponentModel.DataAnnotations;

namespace Theatre_App.Models
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
