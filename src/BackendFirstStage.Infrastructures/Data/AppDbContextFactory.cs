using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using BackendFirstStage.Infrastructures.Services;

namespace BackendFirstStage.Infrastructures.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // DatabaseConnectionService'den connection string'i al
            var connectionString = DatabaseConnectionService.GetConnectionString();

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
