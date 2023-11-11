using Backend.API.Data.Models;

namespace Backend.API.Handlers
{
    public interface IToppingsHandler
    {
        public IEnumerable<Topping> GetToppingList();
    }
}