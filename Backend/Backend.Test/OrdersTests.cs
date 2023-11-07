using System.Text.Json;
using Backend.API.Data;
using Backend.API.Data.DTOs;
using Backend.API.Data.Models;
using Backend.API.Handlers;
using Backend.Test.Mocks;

namespace Backend.Test
{
    public class OrdersTests
    {
        [Fact]
        public async void AddOrderTest()
        {
            Mock<AppDbContext> dbMock = AppDbContextMock.GetMock();
            var handler = new OrdersHandler(dbMock.Object);

            var testData = OrdersTestsData.OrderRequests.Zip(OrdersTestsData.OrderResponses, (first, second) => new Tuple<AddOrderRequest, OrderResponse>(first, second));

            foreach (var item in testData)
            {

                await handler.AddOrderAsync(item.Item1);
                var actualResult = OrderResponse.FromEntity(dbMock.Object.Orders.Where(x => x.Id == item.Item2.Id).First());

                var expectedString = JsonSerializer.Serialize(item.Item2);
                var actualString = JsonSerializer.Serialize(actualResult);

                Assert.Equal(expectedString, actualString);
            }
        }

        [Fact]
        public async void GetOrderListTest()
        {
            Mock<AppDbContext> dbMock = AppDbContextMock.GetMock();
            var handler = new OrdersHandler(dbMock.Object);
            var addRequests = OrdersTestsData.OrderRequests;
            foreach (var request in addRequests)
            {
                await handler.AddOrderAsync(request);
            }

            List<Order> orders = dbMock.Object.Orders.ToList();
            List<OrderResponse> responses = new List<OrderResponse>();
            foreach (var item in orders)
            {
                responses.Add(OrderResponse.FromEntity(item));
            }
            var actualString = JsonSerializer.Serialize(responses);
            var expectedString = JsonSerializer.Serialize(OrdersTestsData.OrderResponses);

            Assert.Equal(expectedString, actualString);
        }
    }
}