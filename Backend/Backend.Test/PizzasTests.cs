using System.Text.Json;
using Backend.API.Data;
using Backend.API.Handlers;
using Backend.Test.Mocks;

namespace Backend.Test
{
    public class PizzasTests
    {
        [Fact]
        public async void GetPizzaListTest()
        {
            Mock<AppDbContext> dbMock = AppDbContextMock.GetMock();
            var handler = new PizzasHandler(dbMock.Object);

            var expectedData = DefaultData.GetPizzas();
            var actualData = await handler.GetPizzaListAsync();

            Assert.Equal(JsonSerializer.Serialize(expectedData), JsonSerializer.Serialize(actualData));

        }
    }
}