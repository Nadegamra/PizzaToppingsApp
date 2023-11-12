using System.Text.Json.Serialization;
using Backend.API.Data.Enums;
using Backend.API.Data.Models;

namespace Backend.API.Data.DTOs
{
    public class AddOrderRequest
    {
        public int PizzaId { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PizzaSize PizzaSize { get; set; }
        public ICollection<int> ToppingIds { get; set; }

        public Order ToEntity()
        {
            var order = new Order
            {
                PizzaId = PizzaId,
                PizzaSize = PizzaSize,
            };

            List<OrderTopping> orderToppings = new List<OrderTopping>();
            foreach (var toppingId in ToppingIds)
            {
                orderToppings.Add(new OrderTopping { ToppingId = toppingId });
            }
            order.OrderToppings = orderToppings;

            return order;
        }
    }
}