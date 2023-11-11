using Backend.API.Data;
using Backend.API.Data.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Backend.API.Repositories
{
    public class ToppingsRepository : IRepository<Topping>
    {
        private readonly AppDbContext dbContext;
        public ToppingsRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public EntityEntry<Topping> Add(Topping entity)
        {
            var res = dbContext.Toppings.Add(entity);
            dbContext.SaveChanges();
            return res;
        }

        public EntityEntry<Topping> Delete(Topping entity)
        {
            var res = dbContext.Toppings.Remove(entity);
            dbContext.SaveChanges();
            return res;
        }

        public Topping? Get(int id)
        {
            return dbContext.Toppings.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Topping> GetAll()
        {
            return dbContext.Toppings;
        }

        public EntityEntry<Topping> Update(Topping entity)
        {
            var res = dbContext.Toppings.Update(entity);
            dbContext.SaveChanges();
            return res;
        }
    }
}