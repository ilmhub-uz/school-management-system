using SchoolManagement.Services.Students.Context;

namespace SchoolManagement.Services.Students.Repositories;

public interface IGenericRepository<TEntity, TDbContext, TKey>
{
    ValueTask<TEntity> CreateAsync(TEntity entity);
    ValueTask<IEnumerable<TEntity>> GetAllAsync();
    ValueTask<TEntity?> GetByIdAsync(TKey id);
    ValueTask UpdateAsync(TEntity entity);
    ValueTask DeleteAsync(TEntity entity);
}

public interface IGenericRepository<TEntity, TKey> : IGenericRepository<TEntity, StudentsDbContext, TKey>
{

}

public interface IGenericRepository<TEntity> : IGenericRepository<TEntity, StudentsDbContext, Guid>
{

}