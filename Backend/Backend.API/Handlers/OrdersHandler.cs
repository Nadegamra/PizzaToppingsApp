using Backend.API.Data;
using Backend.API.Data.DTOs;
using Backend.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.Handlers
{
    public class OrdersHandler
    {
        private readonly AppDbContext dbContext;

        public OrdersHandler(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AddOrderAsync(AddOrderRequest req)
        {
            Order order = new Order { PizzaId = req.PizzaId };
            var res = await dbContext.Orders.AddAsync(order);

            List<OrderTopping> orderToppings = new List<OrderTopping>();
            foreach (var toppingId in req.ToppingIds)
            {
                orderToppings.Add(new OrderTopping { OrderId = res.Entity.Id, ToppingId = toppingId });
            }
            dbContext.OrderToppings.AddRange(orderToppings);

            await dbContext.SaveChangesAsync();

            return true;

        }
        public async Task<OrderResponse> GetOrderAsync(int id)
        {
            Order? order = dbContext.Orders.Include(x => x.OrderToppings).ThenInclude(x => x.Topping).Where(x => x.Id == id).FirstOrDefault();
            if (order == null)
            {
                throw new Exception($"Order with id = {id} does not exist");
            }

            return new OrderResponse
            {
                Id = order.Id,
                PizzaId = order.PizzaId,
                OrderToppings = order.OrderToppings.Select(o => o.Topping).ToList()
            };
        }
        public async Task<IEnumerable<OrderResponse>> GetOrderListAsync()
        {
            return await dbContext.Orders.Select(o => new OrderResponse
            {
                Id = o.Id,
                PizzaId = o.PizzaId,
                OrderToppings = o
                    .OrderToppings
                    .Select(ot => ot.Topping).ToList()

            }).ToListAsync();
        }

    }
}