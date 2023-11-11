using Backend.API.Data;
using Backend.API.Data.Models;
using Backend.API.Handlers;
using Backend.API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
{
    services.AddCors((options) =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins("http://localhost", "https://localhost")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
            });
        });

    services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(databaseName: "Pizzas"));

    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddTransient<IOrdersHandler, OrdersHandler>();
    services.AddTransient<IPizzasHandler, PizzasHandler>();
    services.AddTransient<IToppingsHandler, ToppingsHandler>();
    services.AddTransient<IRepository<Pizza>, PizzaRepository>();
    services.AddTransient<IRepository<Topping>, ToppingsRepository>();
    services.AddTransient<IRepository<Order>, OrdersRepository>();
}

var app = builder.Build();
{
    app.UseCors();

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
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/error");
    }

    app.MapControllers();
}

app.Run();
