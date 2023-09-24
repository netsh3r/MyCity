using My.City.Abstraction.Domain.Entity;
using My.City.Common.Specification;
using JetBrains.Annotations;

namespace My.City.Abstraction.Dal.Repository;

[PublicAPI]
public interface IReadRepository<TEntity, in TPrimaryKey>
    where TEntity : class, IEntity<TPrimaryKey>
{
    Task<TEntity?> GetByIdAsync(TPrimaryKey id, CancellationToken cancellationToken = default);

    Task<TEntity?> GetFirstAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<TEntity>> FindAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default);
    
    Task<IReadOnlyCollection<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default);

    Task<int> CountAsync(Specification<TEntity>? specification, CancellationToken cancellationToken = default);
}

[PublicAPI]
public interface IReadRepository<TEntity> : IReadRepository<TEntity, long> where TEntity : class, IEntity
{

}