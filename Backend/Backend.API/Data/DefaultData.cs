using Backend.API.Data.Models;

namespace Backend.API.Data
{
    public static class DefaultData
    {
        public static List<Topping> GetToppings()
        {
            return new List<Topping> {
                new Topping {Id = 1, Name = "Mozzarella"},
                new Topping {Id = 2, Name = "Pickled bulbs"},
                new Topping {Id = 3, Name = "Pickled cucumbers"},
                new Topping {Id = 4, Name = "Pineapple"},
                new Topping {Id = 5, Name = "Onions"},
                new Topping {Id = 6, Name = "Olives"},
                new Topping {Id = 7, Name = "Pepperoni pepper"},
                new Topping {Id = 8, Name = "Jalapeño Pepper"},
                new Topping {Id = 9, Name = "Tomatoes"},
                new Topping {Id = 10, Name = "Bell pepper"},
                new Topping {Id = 11, Name = "Mushrooms"},
                new Topping {Id = 12, Name = "Fried minced pork"},
                new Topping {Id = 13, Name = "Bacon"},
                new Topping {Id = 14, Name = "Smoked chicken"},
                new Topping {Id = 15, Name = "Smoked beef"},
                new Topping {Id = 16, Name = "Pepperoni sausage"},
                new Topping {Id = 17, Name = "Salami"},
                new Topping {Id = 18, Name = "Pork ham"},
                new Topping {Id = 19, Name = "Hard cheese"},
                new Topping {Id = 20, Name = "Cheese"},
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