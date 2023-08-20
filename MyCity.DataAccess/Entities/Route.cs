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

    /// <summary>
    ///     Длина маршрута
    /// </summary>
    public int Length { get; set; }

    /// <summary>
    ///     Айдишник первой точки маршрута 
    /// </summary>
    public long StartRoutePointId { get; set; }
}