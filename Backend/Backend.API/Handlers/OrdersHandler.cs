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
            decimal pizzaPrice = GetPizzaPriceBySize(req.PizzaSize) + req.ToppingIds.Count();
            int discountPercentage = req.ToppingIds.Count > 3 ? 10 : 0;
            decimal finalPrice = pizzaPrice * (100 - discountPercentage) / 100;

            Order order = new Order { PizzaId = req.PizzaId, PizzaSize = req.PizzaSize, DiscountPercentage = discountPercentage, Price = pizzaPrice, DiscountedPrice = finalPrice };
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
                Price = order.Price,
                DiscountPercentage = order.DiscountPercentage,
                DiscountedPrice = order.DiscountedPrice,
                PizzaSize = order.PizzaSize,
                OrderToppings = order.OrderToppings.Select(o => o.Topping).ToList()
            };
        }
        public async Task<IEnumerable<OrderResponse>> GetOrderListAsync()
        {
            return await dbContext.Orders.Select(o => new OrderResponse
            {
                Id = o.Id,
                PizzaId = o.PizzaId,
                Price = o.Price,
                DiscountPercentage = o.DiscountPercentage,
                DiscountedPrice = o.DiscountedPrice,
                PizzaSize = o.PizzaSize,
                OrderToppings = o
                    .OrderToppings
                    .Select(ot => ot.Topping).ToList()

            }).ToListAsync();
        }

        private decimal GetPizzaPriceBySize(PizzaSize size)
        {
            switch (size)
            {
                case PizzaSize.Small:
                    return 8;
                case PizzaSize.Medium:
                    return 10;
                case PizzaSize.Large:
                    return 12;
                default:
                    throw new Exception("Invalid pizza size");
            }
        }

    }
}