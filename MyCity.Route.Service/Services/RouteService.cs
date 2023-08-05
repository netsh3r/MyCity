using MyCity.Core.Repository;
using MyCity.Core.Services;

namespace MyCity.Route.Service.Services;
using DataAccess.Entities;

public class RouteService : IRouteService
{
    private readonly IRepository<Route> _repositoryRoute;

    public RouteService(IRepository<Route> repositoryRoute)
    {
        _repositoryRoute = repositoryRoute;
    }

    public async Task<Route> CrateAsync(Route route)
    {
        return await _repositoryRoute.CreateAsync(route);
    }

    public async Task<Route> UpdateAsync(Route route)
    {
        return await _repositoryRoute.UpdateAsync(route);
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