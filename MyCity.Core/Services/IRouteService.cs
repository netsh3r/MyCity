using MyCity.Core.Models;
using MyCity.DataAccess.Entities;

namespace MyCity.Core.Services;

public interface IRouteService : IBaseService<Route, RouteDto>
{
    Task<Route> AddRoutePoints(long routeId, IEnumerable<RoutePoints> routePoints);
}