using Backend.API.Data.Models;
using Backend.API.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [ApiController]
    [Route("/api/pizzas/")]
    public class PizzasController : ControllerBase
    {
        private readonly IPizzasHandler handler;

        public PizzasController(IPizzasHandler handler)
        {
            this.handler = handler;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pizza>> GetPizzaList()
        {
            var result = handler.GetPizzaList();
            return Ok(result);
        }
    }
}