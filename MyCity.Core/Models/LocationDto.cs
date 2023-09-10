using MyCity.DataAccess.Entities;
using MyCity.DataAccess.Enums;

namespace MyCity.Core.Models;

/// <summary>
///     DTO локации
/// </summary>
public class LocationDto : BaseDto
{
    /// <summary>
    ///     Имя локации
    /// </summary>
    public string? Name { get; set; }
   
    /// <summary>
    ///     Описание локации
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    ///     Начало время работы локации
    /// </summary>
    public TimeOnly? WorkTimeStart { get; set; }

    /// <summary>
    ///     Окончание время работы локации
    /// </summary>
    public TimeOnly? WorkTimeEnd { get; set; }
    
    /// <summary>
    ///     Тип локации
    /// </summary>
    public int LocationType { get; set; } 

    /// <summary>
    ///     Координаты локации в двухмерной проекции
    /// </summary>
    public Point? Point { get; set; }
}