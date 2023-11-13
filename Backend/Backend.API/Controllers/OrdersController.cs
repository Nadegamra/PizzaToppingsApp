using Backend.API.Data.DTOs;
using Backend.API.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [ApiController]
    [Route("/api/orders/")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersHandler handler;

        public OrdersController(IOrdersHandler handler)
        {
            this.handler = handler;
        }

        [HttpPost]
        public ActionResult<bool> AddOrder(AddOrderRequest req)
        {
            var res = handler.AddOrder(req);
            return Created($"/api/orders/{res.Id}", res);
        }

        [HttpGet("{id}")]
        public ActionResult<OrderResponse> GetOrder(int id)
        {
            var result = handler.GetOrder(id);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderResponse>> GetOrderList()
        {
            var result = handler.GetOrderList();
            return Ok(result);
        }
        [HttpPost("price")]
        public ActionResult<decimal> CalculatePrice(AddOrderRequest req)
        {
            var result = handler.CalculateFinalPrice(req);
            return Ok(result);
        }
    }
}