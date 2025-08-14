using BackendFirstStage.Domain.Entities;
using BackendFirstStage.Applications.Repositories;
using BackendFirstStage.Infrastructures.Data;
using Microsoft.EntityFrameworkCore;
using BackendFirstStage.Infrastructures.Repositories.Seedwork;

namespace BackendFirstStage.Infrastructures.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
    {
        return await _dbSet
            .Where(p => p.Name.Contains(name) && p.IsActive && !p.IsDeleted)
            .ToListAsync();
    }



    public async Task<Product?> GetProductByNameAsync(string name)
    {
        return await _dbSet
            .FirstOrDefaultAsync(p => p.Name == name && p.IsActive && !p.IsDeleted);
    }
}
