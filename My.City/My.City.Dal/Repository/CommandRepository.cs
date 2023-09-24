using My.City.Abstraction.Dal.Repository;
using My.City.Abstraction.Domain.Entity;
using My.City.Dal;
using JetBrains.Annotations;

namespace My.City.DAL.Repository;

[PublicAPI]
public class CommandRepository<TEntity> : GenericCommandRepository<TEntity, long>, ICommandRepository<TEntity> where TEntity : class, IEntity
{
    public CommandRepository(MyCityContext dbContext) : base(dbContext)
    {
    }
}
