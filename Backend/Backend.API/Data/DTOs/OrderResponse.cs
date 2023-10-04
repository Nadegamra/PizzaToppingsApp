using Backend.API.Data.Models;

namespace Backend.API.Data.DTOs
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public List<Topping> OrderToppings { get; set; }
    }
}