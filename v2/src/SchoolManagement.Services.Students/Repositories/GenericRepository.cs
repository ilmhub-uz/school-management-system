using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Students.Context;

namespace SchoolManagement.Services.Students.Repositories;

public class GenericRepository<TEntity, TDbContext, TKey> : IGenericRepository<TEntity, TDbContext, TKey>
    where TDbContext : DbContext where TEntity : class
{
    private readonly DbContext _dbContext;
    protected readonly DbSet<TEntity> Entities;

    public GenericRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
        Entities = _dbContext.Set<TEntity>();
    }

    public async ValueTask<TEntity> CreateAsync(TEntity entity)
    {
        Entities.Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async ValueTask<IEnumerable<TEntity>> GetAllEntitiesAsync()
    {
        return await Entities.ToListAsync();
    }

    public async ValueTask<TEntity?> GetByIdAsync(TKey id)
    {
        return await Entities.FindAsync(id);
    }

    public async ValueTask UpdateAsync(TEntity entity)
    {
        Entities.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async ValueTask DeleteAsync(TEntity entity)
    {
        Entities.Remove(entity);
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