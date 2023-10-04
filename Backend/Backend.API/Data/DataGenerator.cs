using Microsoft.EntityFrameworkCore;

namespace Backend.API.Data
{
    public class DataGenerator
    {
        public static async void Initialize(IServiceProvider serviceProvider)
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

                await context.SaveChangesAsync();
            }
        }
    }
}