using Business.Model.Route;
using Dto.Dal;

namespace Business.Converters;

public interface IRouteConverters
{
    Route Convert(RouteDto routeDto);
    RouteDto Convert(Route routeDto);
}