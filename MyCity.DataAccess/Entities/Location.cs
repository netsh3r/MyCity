namespace MyCity.DataAccess.Entities;

public class Location : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public TimeOnly WorkTimeStart { get; set; }
    public TimeOnly WorkTimeEnd { get; set; }
    public Point Point { get; set; }
}