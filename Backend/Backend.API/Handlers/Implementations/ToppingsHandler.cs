using Backend.API.Data.Models;
using Backend.API.Repositories;

namespace Backend.API.Handlers
{
    public class ToppingsHandler : IToppingsHandler
    {
        private readonly IRepository<Topping> repository;
        public ToppingsHandler(IRepository<Topping> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Topping> GetToppingList()
        {
            return repository.GetAll();
        }
    }
}