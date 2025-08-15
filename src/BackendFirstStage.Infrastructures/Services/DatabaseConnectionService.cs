using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BackendFirstStage.Infrastructures.Data;

namespace BackendFirstStage.Infrastructures.Services;

public static class DatabaseConnectionService
{
    public static IServiceCollection AddDatabaseConnection(this IServiceCollection services, IConfiguration configuration)
    {
        // Connection string'i environment variable'dan al, yoksa fallback kullan
        var connectionString = GetConnectionString();

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

    // Design-time ve test'ler için connection string alma metodu
    public static string GetConnectionString()
    {
        return Environment.GetEnvironmentVariable("MsSqlServer") 
            ?? "Server=localhost;Database=BackendFirstStageDb;Trusted_Connection=true;TrustServerCertificate=true;MultipleActiveResultSets=true";
    }
}
