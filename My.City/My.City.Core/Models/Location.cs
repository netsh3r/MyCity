﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyCity.DataAccess.Enums;

namespace My.City.Core.Models;

/// <summary>
///    Любое место, находщиеся на карте приложения  ( Бар, Музей and etc.. )
/// </summary>
public class Location : BaseEntity
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
    public LocationType? LocationType { get; set; } 

    /// <summary>
    ///     Координаты локации в двухмерной проекции
    /// </summary>
    public Point? Point { get; set; }

    /// <summary>
    /// Ссылка на картинку локации.
    /// </summary>
    public string ImageUrl { get; set; }
}