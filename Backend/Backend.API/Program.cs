using Backend.API.Data;
using Backend.API.Handlers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
{
    services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(databaseName: "Pizzas"));

    services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddTransient<OrdersHandler>();
    services.AddTransient<PizzasHandler>();
    services.AddTransient<ToppingsHandler>();

}

var app = builder.Build();
{


    // Fill database with default data
    using (var scope = app.Services.CreateScope())
    {
        var serviceProvider = scope.ServiceProvider;
        var context = serviceProvider.GetRequiredService<AppDbContext>();
        DataGenerator.Initialize(serviceProvider);
    }

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthorization();

    app.MapControllers();
}

app.Run();
