using Backend.API.Data;
using Moq.EntityFrameworkCore;

namespace Backend.Test.Mocks
{
    public static class AppDbContextMock
    {
        public static Mock<AppDbContext> GetMock()
        {
            var dbMock = new Mock<AppDbContext>();

            dbMock.Setup(x => x.Toppings).ReturnsDbSet(DefaultData.GetToppings());
            dbMock.Setup(x => x.Pizzas).ReturnsDbSet(DefaultData.GetPizzas());

            return dbMock;
        }
    }
}