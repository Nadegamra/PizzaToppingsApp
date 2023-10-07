using System.Text.Json;
using Backend.API.Data;
using Backend.API.Handlers;
using Backend.Test.Mocks;

namespace Backend.Test
{
    public class ToppingsTests
    {
        [Fact]
        public async void GetToppingListTest()
        {
            Mock<AppDbContext> dbMock = AppDbContextMock.GetMock();
            var handler = new ToppingsHandler(dbMock.Object);

            var expectedResult = JsonSerializer.Serialize(DefaultData.GetToppings());
            var actualResult = JsonSerializer.Serialize(await handler.GetToppingListAsync());

            Assert.Equal(expectedResult, actualResult);
        }
    }
}