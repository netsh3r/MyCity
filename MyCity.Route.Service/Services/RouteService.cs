namespace MyCity.Route.Service.Services;

using MyCity.Core.Models;
using MyCity.Core.Repository;
using MyCity.Core.Services;
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

    #region Попытки реализации
    public async Task<ClientRouteDto> CreateRouteAsync(ClientRouteDto clientRouteDto)
    {
        var route = await _repositoryRoute.GetAsync(clientRouteDto.RouteId);
        if (route == null)
        {
            var newRoute = await _repositoryRoute.CreateAsync(new Route
            {
                Name = clientRouteDto.Name,
                Length = clientRouteDto.Length,
                Description = clientRouteDto.Description
            });

            if (newRoute == null)
                return null; //TODO: Сообщать об ошибке или попытаться создать Route ещё раз.
            
            var newRoutePoints = await _repositoryRoutePoints.CreateAsync(new RoutePoints
            {
                RouteId = newRoute.Id,
                RoutePointsObj = clientRouteDto.RoutePoints
            });

            if (newRoutePoints == null)
                return null; //TODO: Сообщать об ошибке или попытаться создать Route ещё раз.

            // Распарсить RoutePointsOnj в Location

        } else
        {
            //Update
        }

        return clientRouteDto;
    }
    #endregion
}