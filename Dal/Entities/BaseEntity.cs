namespace Dal.Entities;

public class BaseEntity : IEntity<long>
{
    public long Id { get; set; }
}