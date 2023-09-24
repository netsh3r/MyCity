using My.City.Abstraction.Domain.Entity;
using JetBrains.Annotations;

namespace My.City.Abstraction.Dal.Repository;

[PublicAPI]
public interface ICommandRepository<TEntity, in TPrimaryKey> : IReadRepository<TEntity, TPrimaryKey>
    where TEntity : class, IEntity<TPrimaryKey>
{
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    TEntity Update(TEntity entity, CancellationToken cancellationToken = default);

    void UpdateRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    void Delete(TEntity entity, CancellationToken cancellationToken = default);

    void DeleteRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
}

[PublicAPI]
public interface ICommandRepository<TEntity> : ICommandRepository<TEntity, long> where TEntity : class, IEntity
{

}