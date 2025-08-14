using BackendFirstStage.Domain.Entities.Seedwork;
using BackendFirstStage.Applications.Repositories.Seedwork;
using BackendFirstStage.Infrastructures.Data;
using Microsoft.EntityFrameworkCore;

namespace BackendFirstStage.Infrastructures.Repositories.Seedwork;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.Where(x => !x.IsDeleted).ToListAsync();
    }

    public virtual async Task<IEnumerable<T>> GetActiveAsync()
    {
        return await _dbSet.Where(x => x.IsActive && !x.IsDeleted).ToListAsync();
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        entity.IsActive = true;
        entity.IsDeleted = false;
        
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public virtual async Task<T> UpdateAsync(T entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        
        _dbSet.Update(entity);
        return entity;
    }

    public virtual async Task<bool> DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null) return false;
        
        _dbSet.Remove(entity);
        return true;
    }

    public virtual async Task<bool> SoftDeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null) return false;
        
        entity.IsDeleted = true;
        entity.DeletedAt = DateTime.UtcNow;
        entity.IsActive = false;
        
        _dbSet.Update(entity);
        return true;
    }

    public virtual async Task<bool> ExistsAsync(int id)
    {
        return await _dbSet.AnyAsync(x => x.Id == id && !x.IsDeleted);
    }

    public virtual Task<int> CountAsync()
    {
        return _dbSet.CountAsync(x => !x.IsDeleted);
    }
}
