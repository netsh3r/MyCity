using My.City.Abstraction.Domain.Entity;
using My.City.Dal;
using My.City.DAL.AbstractRepository;
using JetBrains.Annotations;

namespace My.City.DAL.Repository;

[PublicAPI]
public class GenericQueryRepository<T, TPrimaryKey> : AbstractQueryRepository<T, TPrimaryKey, MyCityContext> 
    where T : class, IEntity<TPrimaryKey>
{
    public GenericQueryRepository(MyCityContext dbContext) : base(dbContext)
    {
    }
}
