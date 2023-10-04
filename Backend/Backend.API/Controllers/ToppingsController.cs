using Backend.API.Data.Models;
using Backend.API.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [ApiController]
    [Route("/api/toppings/")]
    public class ToppingsController : ControllerBase
    {
        private readonly ToppingsHandler handler;

        public ToppingsController(ToppingsHandler handler)
        {
            this.handler = handler;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<Topping>>> GetToppingListAsync()
        {
            try
            {
                var result = await handler.GetToppingListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}