namespace MyCity.DataAccess.Entities;

public class Route : BaseEntity
{
    public string Name { get; set; }
    public int Length { get; set; }
    public long StartRoutePointId { get; set; }
}