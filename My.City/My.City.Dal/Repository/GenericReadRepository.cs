using My.City.Abstraction.Domain.Entity;
using My.City.Dal;
using My.City.DAL.AbstractRepository;
using JetBrains.Annotations;

namespace My.City.DAL.Repository;

[PublicAPI]
public class GenericReadRepository<T, TPrimaryKey> : AbstractReadRepository<T, TPrimaryKey, MyCityContext> 
    where T : class, IEntity<TPrimaryKey>
{
    public GenericReadRepository(MyCityContext dbContext) : base(dbContext)
    {
    }
}
