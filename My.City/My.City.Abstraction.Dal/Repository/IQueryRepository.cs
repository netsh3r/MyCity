using My.City.Abstraction.Domain.Entity;
using JetBrains.Annotations;

namespace My.City.Abstraction.Dal.Repository;

[PublicAPI]
public interface IQueryRepository<TEntity, in TPrimaryKey> : IReadRepository<TEntity, TPrimaryKey>
    where TEntity : class, IEntity<TPrimaryKey>
{
    IQueryable<TEntity> Query();
}

[PublicAPI]
public interface IQueryRepository<TEntity> : IQueryRepository<TEntity, long> where TEntity : class, IEntity
{

}