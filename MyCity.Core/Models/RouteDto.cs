namespace MyCity.Core.Models;

public class RouteDto : BaseDto
{
    public string Name { get; set; }
    public int Length { get; set; }
    public LinkListLocation LinkListLocations { get; set; }
}