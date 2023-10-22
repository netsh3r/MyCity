using Dto.Dal;

namespace Dal.Repositories;

public interface IRepository<TModel, in TPrimaryKey>
    where TModel: class, IDto
{
    public Task SaveChangeAsync(CancellationToken cancellationToken = default);
    public Task<TModel?> GetByIdAsync(TPrimaryKey id, CancellationToken cancellationToken = default);
    public Task<IReadOnlyCollection<TModel>> GetAllAsync(CancellationToken cancellationToken = default);
    public Task<TModel> AddAsync(TModel model, CancellationToken cancellationToken = default);
    public Task<TModel> Update(TModel model, CancellationToken cancellationToken = default);
    public Task Delete(TPrimaryKey id, CancellationToken cancellationToken = default);
    public Task<TModel> AddOrUpdateAsync(TModel model, CancellationToken cancellationToken = default);
}