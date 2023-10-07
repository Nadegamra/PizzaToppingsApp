using Backend.API.Data;
using Backend.API.Data.DTOs;
using Backend.API.Data.Enums;
using Backend.API.Data.Models;

namespace Backend.Test
{
    public class TestData
    {
        private static List<Pizza> pizzas = DefaultData.GetPizzas();
        private static List<Topping> toppings = DefaultData.GetToppings();
        public static List<AddOrderRequest> OrderRequests = new List<AddOrderRequest> {
            new AddOrderRequest
            {
                PizzaId = 2,
                PizzaSize = PizzaSize.Medium, // 10 Eur
                ToppingIds = new List<int> { 1, 4, 9 } // 3 Eur,
            },
            new AddOrderRequest
            {
                PizzaId = 3,
                PizzaSize = PizzaSize.Large, // 12 Eur
                ToppingIds = new List<int> { 2, 7, 10, 11, 15 } // 5 Eur,
            }
        };

        public static List<OrderResponse> OrderResponses = new List<OrderResponse> {
            new OrderResponse
            {
                Id = 1,
                Price = 13.00m, // 10 + 3 = 13.00 Eur
                Pizza = pizzas.Where(x => x.Id == 2).First(),
                PizzaSize = PizzaSize.Medium,
                OrderToppings = toppings.Where(x => new List<int> { 1, 4, 9 }.Contains(x.Id)).ToList()
            },
            new OrderResponse
            {
                Id = 2,
                Price = 15.30m, // (12 + 5)*0.9 = 15.30 Eur
                Pizza = pizzas.Where(x => x.Id == 3).First(),
                PizzaSize = PizzaSize.Large,
                OrderToppings = toppings.Where(x => new List<int> { 2, 7, 10, 11, 15 }.Contains(x.Id)).ToList()
            }
        };
    }
}