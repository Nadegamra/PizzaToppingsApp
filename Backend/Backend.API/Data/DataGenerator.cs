using Microsoft.EntityFrameworkCore;

namespace Backend.API.Data
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (!context.Pizzas.Any())
                {
                    context.Pizzas.AddRange(DefaultData.GetPizzas());
                }
                if (!context.Toppings.Any())
                {
                    context.Toppings.AddRange(DefaultData.GetToppings());
                }
            }
        }
    }
}