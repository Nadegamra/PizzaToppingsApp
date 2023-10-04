using Backend.API.Data;
using Backend.API.Data.DTOs;
using Backend.API.Data.Models;

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
            return false;
        }
        public async Task<Order> GetOrderAsync(int id)
        {
            Order? order = dbContext.Orders.Where(x => x.Id == id).FirstOrDefault();
            if (order == null)
            {
                throw new Exception($"Order with id = {id} does not exist");
            }

            return order;
        }
        public async Task<List<Order>> GetOrderListAsync()
        {
            List<Order> orders = dbContext.Orders.ToList();
            return orders;
        }

    }
}