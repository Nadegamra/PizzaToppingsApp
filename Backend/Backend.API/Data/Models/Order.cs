using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.API.Data.Enums;

namespace Backend.API.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Pizza")]
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        public decimal Price { get; set; }
        public PizzaSize PizzaSize { get; set; }
        public List<OrderTopping> OrderToppings { get; set; }
    }
}