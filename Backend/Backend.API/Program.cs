using Backend.API.Data;
using Backend.API.Handlers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
{
    services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(databaseName: "Pizzas"));

    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddTransient<OrdersHandler>();
    services.AddTransient<PizzasHandler>();
    services.AddTransient<ToppingsHandler>();

}

var app = builder.Build();
{
    using (var scope = app.Services.CreateScope())
    {
        var serviceProvider = scope.ServiceProvider;
        var context = serviceProvider.GetRequiredService<AppDbContext>();
        DataGenerator.Initialize(serviceProvider);
    }

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.MapControllers();
}

app.Run();
