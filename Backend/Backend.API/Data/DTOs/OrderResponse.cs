using Backend.API.Data.Enums;
using Backend.API.Data.Models;

namespace Backend.API.Data.DTOs
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int DiscountPercentage { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; }
        public PizzaSize PizzaSize { get; set; }
        public List<Topping> OrderToppings { get; set; }
    }
}