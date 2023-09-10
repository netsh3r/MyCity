namespace MyCity.Route.Services;

using MyCity.Core.Models;
using MyCity.Core.Repository;
using MyCity.Core.Services;
using DataAccess.Entities;
using Newtonsoft.Json;

public class RouteService : IRouteService
{
    private readonly IRepository<Route> _repositoryRoute;
    private readonly IRepository<RoutePoints> _repositoryRoutePoints;
    private readonly IRepository<Location> _repositoryLocation;

    public RouteService(IRepository<Route> repositoryRoute, IRepository<RoutePoints> repositoryRoutePoints, IRepository<Location> repositoryLocation)
    {
        _repositoryRoute = repositoryRoute;
        _repositoryRoutePoints = repositoryRoutePoints;
        _repositoryLocation = repositoryLocation;
    }

    public async Task<IEnumerable<Route>> ListAsync()
    {
        return await _repositoryRoute.ListAsync();
    }

    public async Task<Route> CreateAsync(RouteDto dto)
    {
        return await _repositoryRoute.CreateAsync(new Route
        {
            Length = dto.Length,
            Name = dto.Name,
            Description = dto.Description
        });
    }

    public async Task<Route> UpdateAsync(RouteDto dto)
    {
        return await _repositoryRoute.UpdateAsync(new Route{
            Id = dto.Id!.Value,
            Length = dto.Length,
            Name = dto.Name,
            Description = dto.Description
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

    #region Route and RoutePoints
    public async Task CreateOrUpdateAsync(ClientRouteDto clientRouteDto)
    {
        try
        {
            var route = await _repositoryRoute.GetAsync(clientRouteDto.RouteId);
            if (route == null)
            {
                await CreateRouteAsync(clientRouteDto);
            }
            else
            {
                await UpdateRouteAsync(clientRouteDto);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    /// <summary>
    /// Создание Route и RoutePoints
    /// </summary>
    /// <param name="clientRouteDto">DTO приходящая с клиента</param>
    /// <returns></returns>
    private async Task CreateRouteAsync(ClientRouteDto clientRouteDto)
    {
        var locations = new List<Location>();
        var route = await _repositoryRoute.CreateAsync(new Route
        {
            Name = clientRouteDto.Name,
            Length = clientRouteDto.Length,
            Description = clientRouteDto.Description
        });

        foreach (var locationId in clientRouteDto.RoutePoints)
        {
            var location = await _repositoryLocation.GetAsync(locationId) ?? null;
            if (location != null)
                locations.Add(location);
        }

        string routePointsObj = JsonConvert.SerializeObject(locations);
        await _repositoryRoutePoints.CreateAsync(new RoutePoints
        {
            RouteId = route.Id,
            RoutePointsObj = routePointsObj
        });
    }

    /// <summary>
    /// Изменение существующего Route и RoutePoints
    /// </summary>
    /// <param name="clientRouteDto"></param>
    /// <returns></returns>
    private async Task UpdateRouteAsync(ClientRouteDto clientRouteDto)
    {
        var locations = new List<Location>();
        var route = await _repositoryRoute.UpdateAsync(new Route
        {
            Name = clientRouteDto.Name,
            Length = clientRouteDto.Length,
            Description = clientRouteDto.Description
        });

        foreach (var locationId in clientRouteDto.RoutePoints)
        {
            var location = await _repositoryLocation.GetAsync(locationId) ?? null;
            if (location != null)
                locations.Add(location);
        }

        string routePointsObj = JsonConvert.SerializeObject(locations);
        await _repositoryRoutePoints.UpdateAsync(new RoutePoints
        {
            RouteId = route.Id,
            RoutePointsObj = routePointsObj
        });
    }
    #endregion
}