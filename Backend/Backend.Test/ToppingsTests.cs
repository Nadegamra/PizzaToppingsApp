using System.Text.Json;
using Backend.API.Data;
using Backend.API.Handlers;
using Backend.API.Repositories;
using Backend.Test.Mocks;

namespace Backend.Test
{
    public class ToppingsTests
    {
        [Fact]
        public void GetToppingListTest()
        {
            Mock<AppDbContext> dbMock = AppDbContextMock.GetMock();
            var handler = new ToppingsHandler(new ToppingsRepository(dbMock.Object));

            var expectedResult = JsonSerializer.Serialize(DefaultData.GetToppings());
            var actualResult = JsonSerializer.Serialize(handler.GetToppingList());

            Assert.Equal(expectedResult, actualResult);
        }
    }
}