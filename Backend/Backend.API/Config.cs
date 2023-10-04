using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.API
{
    public class Config
    {
        public static decimal ToppingPrice = 1.00m;
        public static int DiscountThreshold = 4;
        public static int DiscountPercentage = 10;
        public static int SmallPizzaSize = 8;
        public static int MediumPizzaSize = 10;
        public static int LargePizzaSize = 12;
    }
}