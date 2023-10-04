using Backend.API.Data;
using Backend.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.Handlers
{
    public class ToppingsHandler
    {
        private readonly AppDbContext dbContext;

        public ToppingsHandler(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Topping>> GetToppingListAsync()
        {
            return await dbContext.Toppings.ToListAsync();
        }
    }
}