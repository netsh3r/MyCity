using My.City.Abstraction.Dal.Repository;
using My.City.Abstraction.Domain.Entity;
using My.City.Dal;
using JetBrains.Annotations;

namespace My.City.DAL.Repository;

[PublicAPI]
public class QueryRepository<TEntity> : GenericQueryRepository<TEntity, long>, IQueryRepository<TEntity> where TEntity : class, IEntity
{
    public QueryRepository(MyCityContext dbContext) : base(dbContext)
    {
    }
}
