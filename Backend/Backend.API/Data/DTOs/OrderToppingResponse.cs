using Backend.API.Data.Models;

namespace Backend.API.Data.DTOs
{
    public class OrderToppingResponse
    {
        public int OrderId { get; set; }
        public int ToppingId { get; set; }
        public Topping Topping { get; set; }
    }
}