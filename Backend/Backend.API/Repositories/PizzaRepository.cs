using Backend.API.Data;
using Backend.API.Data.Models;

namespace Backend.API.Repositories
{
    public class PizzaRepository : IRepository<Pizza>
    {
        private readonly AppDbContext dbContext;

        public PizzaRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Pizza Add(Pizza entity)
        {
            var res = dbContext.Add(entity);
            dbContext.SaveChanges();
            return Get(res.Entity.Id);
        }

        public Pizza Delete(Pizza entity)
        {
            var res = dbContext.Remove(entity);
            dbContext.SaveChanges();
            return res.Entity;
        }

        public Pizza? Get(int id)
        {
            return dbContext.Pizzas.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Pizza> GetAll()
        {
            return dbContext.Pizzas;
        }

        public Pizza Update(Pizza entity)
        {
            var res = dbContext.Update(entity);
            dbContext.SaveChanges();
            return Get(res.Entity.Id);
        }
    }
}