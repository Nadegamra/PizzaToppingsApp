using System.ComponentModel.DataAnnotations;

namespace Backend.API.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public List<OrderTopping> OrderToppings { get; set; }
    }
}