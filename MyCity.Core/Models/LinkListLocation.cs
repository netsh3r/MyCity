namespace MyCity.Core.Models;

/// <summary>
///     Модель реализующая точку маршрута
///     Имеет ссылку на следующию точку
///     TODO Переименовать на RoutLocationList
/// </summary>
public class LinkListLocation
{
    /// <summary>
    ///     Id локации, на которую укзаывает точка маршрута
    /// </summary>
    public long CurrentIdLocation { get; set; }

    /// <summary>
    ///     Следующая точка маршрута
    /// </summary>
    public LinkListLocation? NextLocation { get; set; }

    /// <summary>
    ///     Комментарий о точке маршрута
    /// </summary>
    public string? LocationComment { get; set; }
}