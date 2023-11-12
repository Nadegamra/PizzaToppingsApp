using Backend.API.Data.Models;
using Backend.API.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [ApiController]
    [Route("/api/toppings/")]
    public class ToppingsController : ControllerBase
    {
        private readonly IToppingsHandler handler;

        public ToppingsController(IToppingsHandler handler)
        {
            this.handler = handler;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Topping>> GetToppingListAsync()
        {
            var result = handler.GetToppingList();
            return Ok(result);
        }
    }
}