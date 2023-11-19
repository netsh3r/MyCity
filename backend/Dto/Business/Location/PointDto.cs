namespace Business.Model.Location;

public class PointDto : BaseDto
{
    /// <summary>
    ///     Ширина ( Координата X )
    /// </summary>
    public string X { get; set; }

    /// <summary>
    ///     Долгота ( Координата Y ) 
    /// </summary>
    public string Y { get; set; }
}