namespace My.City.Core.Models;

/// <summary>
///     Двухмерная проекция локации
/// </summary>
public class Point : BaseEntity
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