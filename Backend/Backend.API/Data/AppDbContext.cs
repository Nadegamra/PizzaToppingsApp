using Backend.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.Data
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderTopping> OrderToppings { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<Topping> Toppings { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public AppDbContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderTopping>().HasKey(t => new { t.OrderId, t.ToppingId });
            base.OnModelCreating(modelBuilder);
        }
    }
}