using Business.Model.Location;
using Dto.Dal;

namespace Business.Converters.Implementations;

public class PointConverters : IPointConverters
{
    public Point Convert(PointDto pointDto)
        => new()
        {
            Id = pointDto.Id,
            X = pointDto.X,
            Y = pointDto.Y
        };

    public PointDto Convert(Point point)
        => new()
        {
            Id = point.Id,
            X = point.X,
            Y = point.Y
        };
}