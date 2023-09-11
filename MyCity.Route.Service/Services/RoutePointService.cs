using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using MyCity.Core.Models;
using MyCity.Core.Repository;
using MyCity.DataAccess.Entities;

namespace MyCity.Route.Services;

public class RoutePointService
{
    private readonly IRepository<DataAccess.Entities.Route> _repositoryRoute;
    private readonly IRepository<RoutePoints> _repositoryRoutePoints;

    public RoutePointService(IRepository<DataAccess.Entities.Route> repositoryRoute, IRepository<RoutePoints> repositoryRoutePoints)
    {
        _repositoryRoute = repositoryRoute;
        _repositoryRoutePoints = repositoryRoutePoints;
    }

    public async Task<ClientRouteDto> GetAsync(long routeId)
    {
        var route = await _repositoryRoute.GetAsync(routeId);
        var routePoints = await _repositoryRoutePoints.GetAll().FirstOrDefaultAsync(x => x.RouteId == routeId);
        return new ClientRouteDto
        {
            RouteId = routeId,
            RoutePoints = JsonSerializer.Deserialize<ClientRoutePointsDto[]>(routePoints.RoutePointsObj),
            Length = route.Length,
            Description = route.Description,
            Name = route.Name
        };
    }
}