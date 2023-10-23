using Dal.Entities;

namespace Dal.Converter;

public class LocationConverter : IConverter<Dto.Dal.Location, long, Location>
{
    public Dto.Dal.Location? Convert(Location? entity)
        => entity is not null? new()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Point = new ()
            {
                Id = entity.PointId,
            }
        } : null;

    public Location Convert(Dto.Dal.Location model)
        => new()
        {
            Id = model.Id ?? 0,
            Name = model.Name,
            Description = model.Description,
            PointId = model.Point.Id,
            Point = new ()
            {
                Id = model.Point.Id ?? 0,
                X = model.Point.X,
                Y = model.Point.Y
            }
        };
}