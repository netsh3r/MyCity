namespace Business.Model.Location;

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
    ///     Координаты
    /// </summary>
    public PointDto Point { get; set; }
}