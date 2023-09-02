using MyCity.Core.Models;
using MyCity.Core.Repository;
using MyCity.Core.Services;
using MyCity.DataAccess.Migrations;

namespace MyCity.Route.Service.Services;
using DataAccess.Entities;

public class RouteService : IRouteService
{
    private readonly IRepository<Route> _repositoryRoute;
    private readonly IRepository<RoutePoints> _repositoryRoutePoints;

    public RouteService(IRepository<Route> repositoryRoute, IRepository<RoutePoints> repositoryRoutePoints)
    {
        _repositoryRoute = repositoryRoute;
        _repositoryRoutePoints = repositoryRoutePoints;
    }

    public async Task<IEnumerable<Route>> ListAsync()
    {
        return await _repositoryRoute.ListAsync();
    }

    public async Task<Route> CrateAsync(RouteDto dto)
    {
        return await _repositoryRoute.CreateAsync(new Route
        {
            Length = dto.Length,
            Name = dto.Name,
            StartRoutePointId = dto.LinkListLocations.CurrentIdLocation
        });
    }

    public async Task<Route> UpdateAsync(RouteDto dto)
    {
        return await _repositoryRoute.UpdateAsync(new Route{
            Id = dto.Id!.Value,
            Length = dto.Length,
            Name = dto.Name,
            StartRoutePointId = dto.LinkListLocations.CurrentIdLocation
        });
    }

    public async Task DeleteAsync(long id)
    {
        await _repositoryRoute.DeleteAsync(id);
    }

    public async Task<Route> GetAsync(long id)
    {
        return await _repositoryRoute.GetAsync(id);
    }

    #region Изменение маршрута (Добавление, Удаление, Перемещение точки маршрута)
    /// <summary>
    /// Добавление точек в маршрут
    /// </summary>
    /// <param name="routePoints">Точки для добавления</param>
    /// <returns>Маршрут</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Route> AddRoutePoints(long routeId, IEnumerable<RoutePoints> routePoints)
    {
        var route = await _repositoryRoute.GetAsync(routeId);

        foreach (var routePoint in routePoints)
        {
            var point = await _repositoryRoutePoints.GetAsync(routePoint.Id);

        }
            
        throw new NotImplementedException();
    }
    #endregion
}