namespace MyCity.Route.Service.Services;

using MyCity.Core.Models;
using MyCity.Core.Repository;
using MyCity.Core.Services;
using DataAccess.Entities;

public class RouteService : IRouteService
{
    private readonly IRepository<Route> _repositoryRoute;

    public RouteService(IRepository<Route> repositoryRoute)
    {
        _repositoryRoute = repositoryRoute;
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
}