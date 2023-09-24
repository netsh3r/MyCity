using My.City.Abstraction.Dal.Repository;
using My.City.Abstraction.Domain.Entity;
using My.City.Dal.AbstractRepository;

namespace My.City.DAL.AbstractRepository;

public abstract class AbstractQueryRepository<TEntity, TPrimaryKey, TContext> : AbstractReadRepository<TEntity, TPrimaryKey, TContext>, IQueryRepository<TEntity, TPrimaryKey>
    where TEntity : class, IEntity<TPrimaryKey>
    where TContext : EfCoreDbContext
{
    protected AbstractQueryRepository(TContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<TEntity> Query() => DbQuery;
}

