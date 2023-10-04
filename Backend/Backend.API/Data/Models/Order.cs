using System.ComponentModel.DataAnnotations;
using Backend.API.Data.Enums;

namespace Backend.API.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int DiscountPercentage { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; }
        public PizzaSize PizzaSize { get; set; }
        public List<OrderTopping> OrderToppings { get; set; }
    }
}