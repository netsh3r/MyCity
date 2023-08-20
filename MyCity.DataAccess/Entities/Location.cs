namespace MyCity.DataAccess.Entities;

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
    ///     Координаты локации в двухмерной проекции
    /// </summary>
    public Point? Point { get; set; }
}