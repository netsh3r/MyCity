namespace MyCity.DataAccess.Entities;

/// <summary>
///     Двухмерная проекция локации
/// </summary>
public class Point : BaseEntity
{
    public string X { get; set; }
    public string Y { get; set; }
}