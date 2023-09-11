namespace MyCity.Core.Models;

/// <summary>
/// DTO маршрута
/// </summary>
public class RouteDto : BaseDto
{
    /// <summary>
    /// Имя маршрута    
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Длина  маршрута   
    /// </summary>
    public int Length { get; set; }

    /// <summary>
    /// Описание маршрута
    /// </summary>
    public string Description { get; set; }
}