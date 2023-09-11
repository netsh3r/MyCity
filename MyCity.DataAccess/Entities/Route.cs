namespace MyCity.DataAccess.Entities;

/// <summary>
///     Модель маршрута
/// </summary>
public class Route : BaseEntity
{
    /// <summary>
    ///     Имя маршрута 
    /// </summary>
    public string Name { get; set; }
    public string Description { get; set; }
    public int Length { get; set; }
}