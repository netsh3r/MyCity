using My.City.Abstraction.Domain.Entity;

namespace My.City.Core.Models;

/// <summary>
///     Базовый класс сущности
/// </summary>
public class BaseEntity: IEntity
{
    /// <summary>
    ///     Идентификатор
    /// </summary>
    public long Id { get; set; }
}