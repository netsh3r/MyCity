using My.City.Abstraction.Dal.Repository;
using My.City.Abstraction.Domain.Entity;
using My.City.Abstraction.Domain.Specification;
using My.City.Common.Specification;
using My.City.Dal.AbstractRepository;
using Microsoft.EntityFrameworkCore;

namespace My.City.DAL.AbstractRepository;

public abstract class AbstractReadRepository<TEntity, TPrimaryKey, TContext> : IReadRepository<TEntity, TPrimaryKey>
where TEntity : class, IEntity<TPrimaryKey>
where TContext : EfCoreDbContext
{
    protected readonly DbSet<TEntity> DbSet;

    protected AbstractReadRepository(TContext dbContext)
    {
        DbSet = dbContext.Set<TEntity>();
    }

    protected virtual IQueryable<TEntity> DbQuery => DbSet.AsNoTracking().IgnoreAutoIncludes();

    public Task<TEntity?> GetByIdAsync(TPrimaryKey id, CancellationToken cancellationToken = default)
        => GetFirstAsync(new IdSpecification<TEntity, TPrimaryKey>(id), cancellationToken);

    public Task<TEntity?> GetFirstAsync(Specification<TEntity> specification,
        CancellationToken cancellationToken = default)
        => DbQuery.FirstOrDefaultAsync(specification, cancellationToken);

    public async Task<IReadOnlyCollection<TEntity>> FindAsync(Specification<TEntity> specification,
        CancellationToken cancellationToken = default)
        => await DbQuery
            .Where(specification)
            .ToArrayAsync(cancellationToken);
    
    public async Task<IReadOnlyCollection<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        => await DbQuery
            .ToArrayAsync(cancellationToken);

    public Task<bool> ExistsAsync(Specification<TEntity> specification,
        CancellationToken cancellationToken = default)
        => DbQuery.AnyAsync(specification, cancellationToken);

    public Task<int> CountAsync(Specification<TEntity>? specification, CancellationToken cancellationToken = default)
        => specification == null
            ? DbQuery.CountAsync(cancellationToken)
            : DbQuery.CountAsync(specification, cancellationToken);
}

