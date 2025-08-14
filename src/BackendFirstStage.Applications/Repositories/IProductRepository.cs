using BackendFirstStage.Domain.Entities;
using BackendFirstStage.Applications.Repositories.Seedwork;

namespace BackendFirstStage.Applications.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<Product?> GetProductByNameAsync(string name);
    Task<IEnumerable<Product>> GetProductsByNameAsync(string name);
}
