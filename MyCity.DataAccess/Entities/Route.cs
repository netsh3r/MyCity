namespace MyCity.DataAccess.Entities;

public class Route : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Length { get; set; }
}