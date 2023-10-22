using Business.Model.Location;
using Dto.Dal;

namespace Business.Converters.Implementations;

public class LocationConverters : ILocationConverters
{
    public Location Convert(LocationDto locationDto)
        => new()
        {
            Id = locationDto.Id,
            Name = locationDto.Name,
            Description = locationDto.Description,
            Point = new ()
            {
                Id = locationDto.Point.Id,
                X = locationDto.Point.X,
                Y = locationDto.Point.Y,
            },
        };

    public LocationDto Convert(Location locationDto)
        => new()
        {
            Id = locationDto.Id,
            Name = locationDto.Name,
            Description = locationDto.Description,
            Point = new ()
            {
                Id = locationDto.Point.Id,
                X = locationDto.Point.X,
                Y = locationDto.Point.Y,
            },
        };
}