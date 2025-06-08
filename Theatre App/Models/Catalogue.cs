using System.ComponentModel.DataAnnotations;

namespace Theatre_App.Models
{
    public class Catalogue
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
