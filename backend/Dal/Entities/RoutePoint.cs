namespace Dal.Entities;

public class RoutePoint : BaseEntity
{
    public virtual Route Route { get; set; }
    public long RouteId { get; set; }
    public string RoutePointObj { get; set; }
}