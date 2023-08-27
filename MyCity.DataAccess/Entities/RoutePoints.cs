﻿namespace MyCity.DataAccess.Entities;

/// <summary>
///     Точки маршрута 
/// </summary>
public class RoutePoints : BaseEntity
{
    /// <summary>
    ///    Следующая точка маршрута 
    /// </summary>
    public RoutePoints NextRoutePoint { get; set; }

    /// <summary>
    ///     Описание точки маршрута
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    ///     Координаты точки маршрута
    /// </summary>
    public Point Point { get; set; }
}