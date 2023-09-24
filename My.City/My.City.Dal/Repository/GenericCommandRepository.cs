using My.City.Abstraction.Domain.Entity;
using My.City.Dal;
using My.City.DAL.AbstractRepository;
using JetBrains.Annotations;

namespace My.City.DAL.Repository;

[PublicAPI]
public class GenericCommandRepository<T, TPrimaryKey> : AbstractCommandRepository<T, TPrimaryKey, MyCityContext> 
    where T : class, IEntity<TPrimaryKey>
{
    public GenericCommandRepository(MyCityContext dbContext) : base(dbContext)
    {
    }
}
