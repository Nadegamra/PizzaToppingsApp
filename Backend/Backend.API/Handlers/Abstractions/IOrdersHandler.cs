using Backend.API.Data.DTOs;

namespace Backend.API.Handlers
{
    public interface IOrdersHandler
    {
        public OrderResponse AddOrder(AddOrderRequest req);
        public OrderResponse GetOrder(int id);
        public IEnumerable<OrderResponse> GetOrderList();
        public decimal CalculateFinalPrice(AddOrderRequest req);
    }
}