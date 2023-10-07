using Backend.API.Data;
using Backend.API.Data.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Moq.EntityFrameworkCore;

namespace Backend.Test.Mocks
{
    public static class AppDbContextMock
    {
        public static Mock<AppDbContext> GetMock()
        {
            var dbMock = new Mock<AppDbContext>();

            var orders = new List<Order>();
            var orderToppings = new List<OrderTopping>();

            dbMock.Setup(x => x.Toppings).ReturnsDbSet(DefaultData.GetToppings());
            dbMock.Setup(x => x.Pizzas).ReturnsDbSet(DefaultData.GetPizzas());
            dbMock.Setup(x => x.Orders).ReturnsDbSet(orders);
            dbMock.Setup(x => x.OrderToppings).ReturnsDbSet(orderToppings);

            dbMock
                .Setup(x => x.Orders.AddAsync(It.IsAny<Order>(), It.IsAny<CancellationToken>()))
                .Callback((Order model, CancellationToken token) =>
                {
                    model.Id = orders.Count() > 0 ? orders.Last().Id + 1 : 1;
                    model.Pizza = DefaultData.GetPizzas().Where(x => x.Id == model.PizzaId).First();
                    orders.Add(model);
                })
                .Returns((Order model, CancellationToken token) => ValueTask.FromResult(new EntityEntry<Order>
                (new InternalEntityEntry(
                    new Mock<IStateManager>().Object,
                    new RuntimeEntityType("Order", typeof(Order), false, null, null, null, Microsoft.EntityFrameworkCore.ChangeTrackingStrategy.Snapshot, null, false, null),
                    model
                    ))));
            dbMock
                .Setup(x => x.OrderToppings.AddRange(It.IsAny<IEnumerable<OrderTopping>>()))
                .Callback((IEnumerable<OrderTopping> toppings) =>
                {
                    orderToppings.AddRange(toppings);
                    toppings = toppings.Select(x =>
                    {
                        x.Topping = DefaultData.GetToppings().Where(y => y.Id == x.ToppingId).First();
                        return x;
                    });
                    orders.Where(x => x.Id == toppings.First().OrderId).First().OrderToppings = toppings.ToList();

                });

            return dbMock;
        }
    }
}