using Common.Specification;
using Dal.Converter;
using Dal.Entities;
using Dto.Dal;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories.Implementations;

public abstract class AbstractRepository<TModel, TPrimaryKey, TEntity> : IRepository<TModel, TPrimaryKey>
    where TModel : class, IDto
    where TEntity : class, IEntity<TPrimaryKey>
{
    protected readonly EfCoreDbContext _context;
    protected readonly DbSet<TEntity> DbSet;
    protected readonly IConverter<TModel, TPrimaryKey, TEntity> _converter;
    protected IQueryable<TEntity> DbQuery => DbSet.AsNoTracking().IgnoreAutoIncludes();

    public AbstractRepository(EfCoreDbContext context, IConverter<TModel, TPrimaryKey, TEntity> converter)
    {
        _context = context;
        _converter = converter;
        DbSet = context.Set<TEntity>();
    }

    public async Task SaveChangeAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<TModel?> GetByIdAsync(TPrimaryKey id, CancellationToken cancellationToken = default)
        => _converter.Convert(await DbQuery.FirstOrDefaultAsync(new IdSpecification<TEntity, TPrimaryKey>(id), cancellationToken));

    public async Task<IReadOnlyCollection<TModel>> GetAllAsync(CancellationToken cancellationToken = default)
        => (await DbQuery
            .ToArrayAsync(cancellationToken)).Select(x => _converter.Convert(x)).ToArray();

    public async Task<TModel> AddAsync(TModel model, CancellationToken cancellationToken = default)
    {
        var entryEntity = await DbSet.AddAsync(_converter.Convert(model), cancellationToken);
        await SaveChangeAsync(cancellationToken);
        return _converter.Convert(entryEntity.Entity);
    }

    public async Task<TModel> Update(TModel model, CancellationToken cancellationToken = default)
    {
        var newEntity = _converter.Convert(model);
        var entity = DbSet.Local.FirstOrDefault(new IdSpecification<TEntity, TPrimaryKey>(newEntity.Id));
        if (entity is null)
        {
            entity = newEntity;
            DbSet.Update(entity);
        }
        else
        {
            _context.Entry(entity).CurrentValues.SetValues(newEntity);
        }
        
        await SaveChangeAsync(cancellationToken);
        return _converter.Convert(entity);
    }

    public async Task Delete(TPrimaryKey id, CancellationToken cancellationToken)
    {
        DbSet.Remove(_converter.Convert(await GetByIdAsync(id)));
        await SaveChangeAsync(cancellationToken);
    }

    public async Task<TModel> AddOrUpdateAsync(TModel model, CancellationToken cancellationToken = default)
    {
        if (model.Id is null)
        {
            return await AddAsync(model, cancellationToken);
        }

        return await Update(model, cancellationToken);
    }
}