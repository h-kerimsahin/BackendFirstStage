using BackendFirstStage.Applications.Repositories;
using BackendFirstStage.Applications.Repositories.Seedwork;
using BackendFirstStage.Applications.Services;
using BackendFirstStage.Infrastructures.Middleware;
using BackendFirstStage.Infrastructures.Repositories;
using BackendFirstStage.Infrastructures.Repositories.Seedwork;
using BackendFirstStage.Infrastructures.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add Database Connection
//var connStr = Environment.GetEnvironmentVariable("MsSqlServer");
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connStr));
builder.Services.AddDatabaseConnection(builder.Configuration);

// Add Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Add Services
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Global Exception Handler Middleware
app.UseGlobalExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();
