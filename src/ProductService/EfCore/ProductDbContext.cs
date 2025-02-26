using Microsoft.EntityFrameworkCore;
using ProductService.Models;

namespace ProductService.EfCore;

public class ProductDbContext : DbContext
{
    public DbSet<Product> Product { get; set; }

    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("ProductService");

        // Optional: Configure entity relationships or constraints here
        modelBuilder.Entity<Product>().HasKey(u => u.Id);
        modelBuilder.Entity<Product>().Property(u => u.Name).IsRequired();
        modelBuilder.Entity<Product>().Property(u => u.Price).IsRequired();
    }
}