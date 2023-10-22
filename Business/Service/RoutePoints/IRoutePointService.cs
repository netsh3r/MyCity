using Business.Model.RoutePoints;

namespace Business.Service.RoutePoints;

public interface IRoutePointService
{
    Task<RoutePointDto[]> GetAsync(long routeId);
    Task<RoutePointDto[]> CreateOrUpdateAsync(long routeId, RoutePointDto[] dto);
}