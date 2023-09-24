using My.City.Abstraction.Dal.Repository;
using My.City.Abstraction.Domain.Entity;
using My.City.Dal.AbstractRepository;

namespace My.City.DAL.AbstractRepository;

public abstract class AbstractCommandRepository<TEntity, TPrimaryKey, TContext> : AbstractReadRepository<TEntity, TPrimaryKey, TContext>, ICommandRepository<TEntity, TPrimaryKey>
    where TEntity : class, IEntity<TPrimaryKey>
    where TContext : EfCoreDbContext
{
    protected AbstractCommandRepository(TContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<TEntity> DbQuery => DbSet;

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var entryEntity = await DbSet.AddAsync(entity, cancellationToken);

        return entryEntity.Entity;
    }

    public Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        => DbSet.AddRangeAsync(entities, cancellationToken);

    public TEntity Update(TEntity entity, CancellationToken cancellationToken = default)
    {
        var entryEntity = DbSet.Update(entity);

        return entryEntity.Entity;
    }

    public void UpdateRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        => DbSet.UpdateRange(entities);

    public void Delete(TEntity entity, CancellationToken cancellationToken = default)
        => DbSet.Remove(entity);

    public void DeleteRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        => DbSet.RemoveRange(entities);
}

