using JetBrains.Annotations;

namespace My.City.Abstraction.Dal.Repository;

[PublicAPI]
public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);

    Task SaveChangesAsync(bool isInTransactionScope, CancellationToken cancellationToken = default);
}