using JetBrains.Annotations;

namespace My.City.Abstraction.Domain.Entity;

[PublicAPI]
public interface IEntity<TPrimaryKey>
{
    TPrimaryKey Id { get; set; }
}

public interface IEntity : IEntity<long>
{
}