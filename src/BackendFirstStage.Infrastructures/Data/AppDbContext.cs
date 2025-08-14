using BackendFirstStage.Domain.Entities;
using BackendFirstStage.Infrastructures.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BackendFirstStage.Infrastructures.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Apply configurations
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
    }
}
