using Backend.API.Data.DTOs;
using Backend.API.Data.Enums;
using Backend.API.Data.Models;
using Backend.API.Repositories;

namespace Backend.API.Handlers
{
    public class OrdersHandler : IOrdersHandler
    {
        private readonly IRepository<Order> repository;

        public OrdersHandler(IRepository<Order> repository)
        {
            this.repository = repository;
        }

        public OrderResponse AddOrder(AddOrderRequest req)
        {
            Order order = req.ToEntity();
            order.Price = CalculateFinalPrice(req);

            var res = repository.Add(order);
            return OrderResponse.FromEntity(res.Entity);
        }

        public OrderResponse? GetOrder(int id)
        {
            Order? order = repository.Get(id);
            return order == null ? null : OrderResponse.FromEntity(order);
        }

        public IEnumerable<OrderResponse> GetOrderList()
        {
            return repository.GetAll().Select(OrderResponse.FromEntity);
        }

        private decimal CalculateFinalPrice(AddOrderRequest req)
        {
            decimal pizzaPrice = GetPizzaPriceBySize(req.PizzaSize) + req.ToppingIds.Count() * Config.ToppingPrice;
            int discountPercentage = req.ToppingIds.Count >= Config.DiscountThreshold ? Config.DiscountPercentage : 0;
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