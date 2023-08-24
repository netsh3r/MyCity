namespace MyCity.Core.Models;

/// <summary>
///     DTO маршрута для для внешних запросов
/// </summary>
public class RouteDto : BaseDto
{
    /// <summary>
    ///     Имя маршрута    
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Длина  маршрута   
    /// </summary>
    public int Length { get; set; }

    /// <summary>
    ///     Модель данных, указывающая на первую точку маршрута
    ///     TODO Правильно ли хранить только первую точку маршрута? 
    /// </summary>
    public LinkListLocation LinkListLocations { get; set; }
}