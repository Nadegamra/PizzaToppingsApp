using Backend.API.Data;
using Backend.API.Data.DTOs;
using Backend.API.Data.Enums;
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
            Order order = req.ToEntity();
            order.Price = CalculateFinalPrice(req);

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
            Order? order = dbContext.Orders
                            .Include(x => x.OrderToppings).ThenInclude(x => x.Topping)
                            .Include(x => x.Pizza)
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            if (order is null)
            {
                throw new Exception($"Order with id = {id} does not exist");
            }

            return OrderResponse.FromEntity(order);
        }
        public async Task<IEnumerable<OrderResponse>> GetOrderListAsync()
        {
            return await dbContext.Orders
                            .Include(x => x.OrderToppings).ThenInclude(x => x.Topping)
                            .Include(x => x.Pizza)
                            .Select(o => OrderResponse.FromEntity(o))
                            .ToListAsync();
        }
        private decimal CalculateFinalPrice(AddOrderRequest req)
        {
            decimal pizzaPrice = GetPizzaPriceBySize(req.PizzaSize) + req.ToppingIds.Count() * Config.ToppingPrice;
            int discountPercentage = req.ToppingIds.Count > Config.DiscountThreshold ? Config.DiscountPercentage : 0;
            return pizzaPrice * (100 - discountPercentage) / 100;
        }

        private decimal GetPizzaPriceBySize(PizzaSize size)
        {
            switch (size)
            {
                case PizzaSize.Small:
                    return Config.SmallPizzaSize;
                case PizzaSize.Medium:
                    return Config.MediumPizzaSize;
                case PizzaSize.Large:
                    return Config.LargePizzaSize;
                default:
                    throw new Exception("Invalid pizza size");
            }
        }
    }
}