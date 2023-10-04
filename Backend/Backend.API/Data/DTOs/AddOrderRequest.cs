using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.API.Data.DTOs
{
    public class AddOrderRequest
    {
        public int PizzaId { get; set; }
        public ICollection<int> ToppingIds { get; set; }
    }
}