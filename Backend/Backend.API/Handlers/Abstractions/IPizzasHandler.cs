using Backend.API.Data.Models;

namespace Backend.API.Handlers
{
    public interface IPizzasHandler
    {
        public IEnumerable<Pizza> GetPizzaList();
    }
}