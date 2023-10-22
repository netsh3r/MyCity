namespace Business.Model.Location;

public class LocationListDto : BaseDto
{
    /// <summary>
    ///     Имя локации
    /// </summary>
    public string? Name { get; set; }
   
    /// <summary>
    ///     Описание локации
    /// </summary>
    public string? Description { get; set; }
    public long? PointId { get; set; }
}