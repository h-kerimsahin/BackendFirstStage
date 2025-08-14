using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BackendFirstStage.Infrastructures.Data;

namespace BackendFirstStage.Infrastructures.Services;

public static class DatabaseConnectionService
{
    public static IServiceCollection AddDatabaseConnection(this IServiceCollection services, IConfiguration configuration)
    {
        // Connection string'i environment variable'dan al fallback AppSettings'e bak
        var connectionString = Environment.GetEnvironmentVariable("MsSqlServer")  ?? configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Database connection string is not configured. Please set DB_CONNECTION_STRING environment variable or add DefaultConnection to appsettings.json");
        }

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString, sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 3,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
            });
        });

        return services;
    }
}
