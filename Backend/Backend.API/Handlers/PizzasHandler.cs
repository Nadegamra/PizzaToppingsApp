using Backend.API.Data;
using Backend.API.Data.Models;

namespace Backend.API.Handlers
{
    public class PizzasHandler
    {
        private readonly AppDbContext dbContext;

        public PizzasHandler(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Pizza>> GetPizzaListAsync()
        {
            return dbContext.Pizzas.ToList();
        }
    }
}