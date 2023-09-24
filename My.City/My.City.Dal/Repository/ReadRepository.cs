using My.City.Abstraction.Dal.Repository;
using My.City.Abstraction.Domain.Entity;
using My.City.Dal;
using JetBrains.Annotations;

namespace My.City.DAL.Repository;

[PublicAPI]
public class ReadRepository<TEntity> : GenericReadRepository<TEntity, long>, IReadRepository<TEntity> where TEntity : class, IEntity
{
    public ReadRepository(MyCityContext dbContext) : base(dbContext)
    {
    }
}
