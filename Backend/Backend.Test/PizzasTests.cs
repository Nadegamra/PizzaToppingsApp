using System.Text.Json;
using Backend.API.Data;
using Backend.API.Handlers;
using Backend.API.Repositories;
using Backend.Test.Mocks;

namespace Backend.Test
{
    public class PizzasTests
    {
        [Fact]
        public void GetPizzaListTest()
        {
            Mock<AppDbContext> dbMock = AppDbContextMock.GetMock();
            var handler = new PizzasHandler(new PizzaRepository(dbMock.Object));

            var expectedResult = JsonSerializer.Serialize(DefaultData.GetPizzas());
            var actualResult = JsonSerializer.Serialize(handler.GetPizzaList());

            Assert.Equal(expectedResult, actualResult);

        }
    }
}