using Business.Model.Location;
using Dto.Dal;

namespace Business.Converters;

public interface ILocationConverters
{
    Location Convert(LocationDto locationDto);
    LocationDto Convert(Location locationDto);
}