using Backend.API.Data;
using Backend.API.Data.Models;
using Backend.API.Repositories;

namespace Backend.API.Handlers
{
    public class PizzasHandler : IPizzasHandler
    {
        private readonly IRepository<Pizza> repository;

        public PizzasHandler(IRepository<Pizza> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Pizza> GetPizzaList()
        {
            return repository.GetAll().ToList();
        }
    }
}