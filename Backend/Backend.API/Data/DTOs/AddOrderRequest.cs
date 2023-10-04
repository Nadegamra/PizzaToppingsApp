using Backend.API.Data.Enums;
using Backend.API.Data.Models;

namespace Backend.API.Data.DTOs
{
    public class AddOrderRequest
    {
        public int PizzaId { get; set; }
        public PizzaSize PizzaSize { get; set; }
        public ICollection<int> ToppingIds { get; set; }

        public Order ToEntity()
        {
            return new Order
            {
                PizzaId = PizzaId,
                PizzaSize = PizzaSize,
            };
        }
    }
}