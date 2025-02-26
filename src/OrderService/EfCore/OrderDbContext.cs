using Microsoft.EntityFrameworkCore;
using OrderService.EfCore.Configuration;
using OrderService.Models;

namespace OrderService.EfCore;

public class OrderDbContext : DbContext
{
    public DbSet<Order> Order{ get; set; }
    public DbSet<OrderItem> OrderItems{ get; set; }


    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("OrderService");

        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
    }

}