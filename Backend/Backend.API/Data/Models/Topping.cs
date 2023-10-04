using System.ComponentModel.DataAnnotations;

namespace Backend.API.Data.Models
{
    public class Topping
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}