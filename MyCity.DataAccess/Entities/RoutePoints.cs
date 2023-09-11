namespace MyCity.DataAccess.Entities;

/// <summary>
///     Точки маршрута 
/// </summary>
public class RoutePoints : BaseEntity
{
    public long RouteId { get; set; }
    public string RoutePointsObj { get; set; }
}