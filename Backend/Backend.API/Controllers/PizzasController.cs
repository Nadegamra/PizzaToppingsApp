using Backend.API.Data.Models;
using Backend.API.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [ApiController]
    [Route("/api/pizzas/")]
    public class PizzasController : ControllerBase
    {
        private readonly PizzasHandler handler;

        public PizzasController(PizzasHandler handler)
        {
            this.handler = handler;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<Pizza>>> GetPizzaListAsync()
        {
            try
            {
                var result = await handler.GetPizzaListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}