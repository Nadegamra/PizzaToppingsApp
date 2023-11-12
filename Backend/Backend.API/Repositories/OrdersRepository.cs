using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.API.Data;
using Backend.API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Backend.API.Repositories
{
    public class OrdersRepository : IRepository<Order>
    {
        private readonly AppDbContext dbContext;

        public OrdersRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public EntityEntry<Order> Add(Order entity)
        {
            var res = dbContext.Orders.Add(entity);

            foreach (var topping in entity.OrderToppings)
            {
                topping.OrderId = res.Entity.Id;
            }

            dbContext.OrderToppings.AddRange(entity.OrderToppings);
            dbContext.SaveChanges();

            return res;
        }

        public EntityEntry<Order> Delete(Order entity)
        {
            var res = dbContext.Orders.Remove(entity);
            dbContext.SaveChanges();
            return res;
        }

        public Order? Get(int id)
        {
            return dbContext.Orders
                    .Include(x => x.OrderToppings).ThenInclude(x => x.Topping)
                    .Include(x => x.Pizza)
                    .Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Order> GetAll()
        {
            return dbContext.Orders
                    .Include(x => x.OrderToppings).ThenInclude(x => x.Topping)
                    .Include(x => x.Pizza);
        }

        public EntityEntry<Order> Update(Order entity)
        {
            var res = dbContext.Orders.Update(entity);
            dbContext.SaveChanges();
            return res;
        }
    }
}