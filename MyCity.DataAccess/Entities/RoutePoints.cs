namespace MyCity.DataAccess.Entities;

public class RoutePoints : BaseEntity
{
    public RoutePoints NextRoutePoint { get; set; }
    public string Description { get; set; }
    public Point Point { get; set; }
}