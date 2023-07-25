using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Students.Context;

namespace SchoolManagement.Services.Students.Repositories;

public class GenericRepository<TEntity, TDbContext, TKey> : IGenericRepository<TEntity, TDbContext, TKey>
    where TDbContext : DbContext where TEntity : class
{
    private readonly DbContext _dbContext;
    private readonly DbSet<TEntity> _entities;

    public GenericRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
        _entities = _dbContext.Set<TEntity>();
    }

    public async ValueTask<TEntity> CreateAsync(TEntity entity)
    {
        _entities.Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async ValueTask<IEnumerable<TEntity>> GetAllEntitiesAsync()
    {
        return await _entities.ToListAsync();
    }

    public async ValueTask<TEntity?> GetByIdAsync(TKey id)
    {
        return await _entities.FindAsync(id);
    }

    public async ValueTask UpdateAsync(TEntity entity)
    {
        _entities.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async ValueTask DeleteAsync(TEntity entity)
    {
        _entities.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}

public class GenericRepository<TEntity, TKey> : GenericRepository<TEntity, StudentsDbContext, TKey>, IGenericRepository<TEntity, TKey>
    where TEntity : class
{
    public GenericRepository(StudentsDbContext dbContext) : base(dbContext)
    {
    }
}

public class GenericRepository<TEntity> : GenericRepository<TEntity, StudentsDbContext, Guid>, IGenericRepository<TEntity>
    where TEntity : class
{
    public GenericRepository(StudentsDbContext dbContext) : base(dbContext)
    {
    }
}