using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult HandleError() => Problem();
    }
}