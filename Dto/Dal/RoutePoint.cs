namespace Dto.Dal;

public class RoutePoint : BaseDto
{
    public virtual Route Route { get; set; }
    public long RouteId { get; set; }
    public string RoutePointObj { get; set; }
}