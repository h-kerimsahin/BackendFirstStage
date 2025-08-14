using BackendFirstStage.Domain.Entities.Seedwork;

namespace BackendFirstStage.Applications.Repositories.Seedwork;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetActiveAsync();
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<bool> DeleteAsync(int id);
    Task<bool> SoftDeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<int> CountAsync();
}
