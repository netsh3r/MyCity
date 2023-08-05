namespace MyCity.DataAccess.Entities;

public class RoutePoints : BaseEntity
{
    public long PointId { get; set; }
    public RoutePoints NextRoutePoint { get; set; }
    public string Description { get; set; }
}