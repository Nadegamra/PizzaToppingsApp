using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.API.Data.Enums;

namespace Backend.API.Data.DTOs
{
    public class AddOrderRequest
    {
        public int PizzaId { get; set; }
        public PizzaSize PizzaSize { get; set; }
        public ICollection<int> ToppingIds { get; set; }
    }
}