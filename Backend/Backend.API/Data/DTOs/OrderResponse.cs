using Backend.API.Data.Enums;
using Backend.API.Data.Models;

namespace Backend.API.Data.DTOs
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public Pizza Pizza { get; set; }
        public decimal Price { get; set; }
        public PizzaSize PizzaSize { get; set; }
        public List<Topping> OrderToppings { get; set; }

        public static OrderResponse FromEntity(Order o)
        {
            return new OrderResponse
            {
                Id = o.Id,
                Pizza = o.Pizza,
                PizzaSize = o.PizzaSize,
                Price = o.Price,
                OrderToppings = o.OrderToppings.Select(x => x.Topping).ToList()
            };
        }
    }
}