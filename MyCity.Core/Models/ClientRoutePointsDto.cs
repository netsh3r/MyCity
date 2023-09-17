namespace MyCity.Core.Models;

public class ClientRoutePointsDto
{
    /// <summary>
    /// Идентификатор локации
    /// </summary>
    public LocationDto Location { get; set; }
    
    /// <summary>
    /// Описание точки
    /// </summary>
    public string Description { get; set; }
}