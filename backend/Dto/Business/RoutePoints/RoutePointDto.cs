using Business.Model.Location;

namespace Business.Model.RoutePoints;

public class RoutePointDto
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