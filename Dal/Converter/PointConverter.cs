using Dto.Dal;

namespace Dal.Converter;

public class PointConverter : IConverter<Point, long, Entities.Point>
{
    public Point Convert(Entities.Point entity)
        => new()
        {
            Id = entity.Id,
            X = entity.X,
            Y = entity.Y
        };

    public Entities.Point Convert(Point model)
        => new()
        {
            Id = model.Id ?? 0,
            X = model.X,
            Y = model.Y
        };
}