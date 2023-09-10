namespace MyCity.Route.Services;

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

    #region Попытки реализации
    public async Task<ClientRouteDto> CreateOrUpdateAsync(ClientRouteDto clientRouteDto)
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
            throw new Exception(message:"");
        } 
        return clientRouteDto;
    }

    //Create
    private async Task CreateRouteAsync(ClientRouteDto clientRouteDto)
    {
        var route = await _repositoryRoute.CreateAsync(new Route
        {
            Name = clientRouteDto.Name,
            Length = clientRouteDto.Length,
            Description = clientRouteDto.Description
        });

        var routePoints = await _repositoryRoutePoints.CreateAsync(new RoutePoints
        {
            RouteId = route.Id,
            RoutePointsObj = clientRouteDto.RoutePoints
        });
    }

    //Update
    private async Task UpdateRouteAsync(ClientRouteDto clientRouteDto)
    {

    }
    #endregion
}