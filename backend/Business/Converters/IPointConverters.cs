using Business.Model.Location;
using Dto.Dal;

namespace Business.Converters;

public interface IPointConverters
{
    Point Convert(PointDto pointDto);
    PointDto Convert(Point point);
}