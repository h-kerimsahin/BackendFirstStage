using BackendFirstStage.Applications.Repositories;
using BackendFirstStage.Applications.Repositories.Seedwork;
using BackendFirstStage.Infrastructures.Repositories;
using BackendFirstStage.Applications.Services;
using BackendFirstStage.Infrastructures.Services;
using BackendFirstStage.Infrastructures.Repositories.Seedwork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add Database Connection
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

app.UseAuthorization();

app.MapControllers();

app.Run();
