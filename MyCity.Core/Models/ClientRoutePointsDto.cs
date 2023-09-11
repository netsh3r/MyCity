namespace MyCity.Core.Models;

public class ClientRoutePointsDto
{
    /// <summary>
    /// Идентификатор локации
    /// </summary>
    public long LocationId { get; set; }
    
    /// <summary>
    /// Описание точки
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Иденкс точки
    /// </summary>
    public int Index { get; set; }
}