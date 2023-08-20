namespace MyCity.Core.Models;

/// <summary>
///     DTO маршрута для для внешних запросов
/// </summary>
public class RouteDto : BaseDto
{
    public string Name { get; set; }
    public int Length { get; set; }
    public LinkListLocation LinkListLocations { get; set; }
}