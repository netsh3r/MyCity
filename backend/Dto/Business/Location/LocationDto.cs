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
    ///     Координаты
    /// </summary>
    public PointDto Point { get; set; }
    public string? Href { get; set; }
}