using SchoolManagement.Services.Students.Context;

namespace SchoolManagement.Services.Students.Repositories;

public interface IGenericRepository<TEntity, TDbContext, TKey>
{
	ValueTask<IEnumerable<TEntity>> Get();
	ValueTask<TEntity?> Get(TKey id);
	ValueTask<TEntity> CreateAsync(TEntity entity);
}

public interface IGenericRepository<TEntity, TKey> : IGenericRepository<TEntity, StudentsDbContext, TKey>
{

}

public interface IGenericRepository<TEntity> : IGenericRepository<TEntity, StudentsDbContext, Guid>
{

}