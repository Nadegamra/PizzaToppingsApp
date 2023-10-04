using Backend.API.Data.Models;

namespace Backend.API.Data
{
    public static class DefaultData
    {
        public static List<Topping> GetToppings()
        {
            return new List<Topping> {
                new Topping {Id = 1, Name = "Mozzarella", Price=1.5m },
                new Topping {Id = 2, Name = "Pickled bulbs", Price=1.5m },
                new Topping {Id = 3, Name = "Pickled cucumbers", Price=1.5m },
                new Topping {Id = 4, Name = "Pineapple", Price=1.5m },
                new Topping {Id = 5, Name = "Onions", Price=1.3m },
                new Topping {Id = 6, Name = "Olives", Price=1.3m },
                new Topping {Id = 7, Name = "Pepperoni pepper", Price=1.5m },
                new Topping {Id = 8, Name = "Jalapeño Pepper", Price=1.5m },
                new Topping {Id = 9, Name = "Tomatoes", Price=1.5m },
                new Topping {Id = 10, Name = "Bell pepper", Price=1.5m },
                new Topping {Id = 11, Name = "Mushrooms", Price=1.8m },
                new Topping {Id = 12, Name = "Fried minced pork", Price=1.8m },
                new Topping {Id = 13, Name = "Bacon", Price=1.8m },
                new Topping {Id = 14, Name = "Smoked chicken", Price=2.1m },
                new Topping {Id = 15, Name = "Smoked beef", Price=1.8m },
                new Topping {Id = 16, Name = "Pepperoni sausage", Price=1.8m },
                new Topping {Id = 17, Name = "Salami", Price=1.8m },
                new Topping {Id = 18, Name = "Pork ham", Price=1.8m },
                new Topping {Id = 19, Name = "Hard cheese", Price=1.8m },
                new Topping {Id = 20, Name = "Cheese", Price=1.8m },
            };
        }

        public static List<Pizza> GetPizzas()
        {
            return new List<Pizza> {
                new Pizza {Id = 1, Name = "Brooklyn", Description = "Italian tomato sauce, chicken, ham, salami, smoked beef, peppers, pepperoni peppers, cheese stew, basil"},
                new Pizza {Id = 2, Name = "Capricciosa", Description = "Italian tomato sauce, ham, mushrooms, olives, cheese sauce, basil"},
                new Pizza {Id = 3, Name = "Ham", Description = "Italian tomato sauce, ham, cheese stew, basil"},
                new Pizza {Id = 4, Name = "Hawaiian", Description = "Italian tomato sauce, ham, pineapple, cheese stew, basil"},
                new Pizza {Id = 5, Name = "Buffalo", Description = "Italian tomato sauce, chicken breast, onions, blue cheese sauce, tobasco sauce, cheese stew, basil"},
                new Pizza {Id = 6, Name = "Meat lovers", Description = "Italian tomato sauce, salami, bacon, ham, roast beef, cheese stew, basil"},
                new Pizza {Id = 7, Name = "Ranches", Description = "Italian tomato sauce, bacon, mushrooms, onions, pickles, cheese stew, basil"},
                new Pizza {Id = 8, Name = "Canadian", Description = "Italian tomato sauce, bacon, roast beef, tomatoes, onions, cheese stew, basil"},
                new Pizza {Id = 9, Name = "Classic pepperoni", Description = "Italian tomato sauce, pepperoni sausage, cheese gauda, basil"},
                new Pizza {Id = 10, Name = "Deluxe", Description = "Italian tomato sauce, minced meat, salami, roasted peppers, mushrooms, onions, cheese stew, basil"},
            };
        }
    }
}