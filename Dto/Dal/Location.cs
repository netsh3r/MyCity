namespace Dto.Dal;

public class Location : BaseDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Point Point { get; set; }
}