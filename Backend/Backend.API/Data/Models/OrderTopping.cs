using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.API.Data.Models
{
    public class OrderTopping
    {
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Topping")]
        public int ToppingId { get; set; }
        public Topping Topping { get; set; }
    }
}