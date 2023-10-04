using System.ComponentModel.DataAnnotations;

namespace Backend.API.Data.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}