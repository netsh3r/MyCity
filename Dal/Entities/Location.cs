namespace Dal.Entities;

public class Location : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Point Point { get; set; }
    public long? PointId { get; set; }
}