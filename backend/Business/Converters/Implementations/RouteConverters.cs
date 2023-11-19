using Business.Model.Route;
using Dto.Dal;

namespace Business.Converters.Implementations;

public class RouteConverters : IRouteConverters
{
    public Route Convert(RouteDto routeDto)
        => new()
        {
            Id = routeDto.Id,
            Name = routeDto.Name,
            Description = routeDto.Description,
        };

    public RouteDto Convert(Route routeDto)
        => new()
        {
            Id = routeDto.Id,
            Name = routeDto.Name,
            Description = routeDto.Description,
            RoutePointDto = null
        };
}