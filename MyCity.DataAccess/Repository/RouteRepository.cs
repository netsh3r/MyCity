using Microsoft.EntityFrameworkCore;
using MyCity.Core.Repository;
using MyCity.DataAccess.Entities;

namespace MyCity.DataAccess.Repository;

/// <summary>
///     Репозиторий маршрута
/// </summary>
public class RouteRepository : IRepository<Route>
{
    public async Task<Route> CreateAsync(Route route)
    {
        using var dbContext = new ApplicationContext();
        await dbContext.AddAsync(route);
        return route;
    }

    public Task<Route> UpdateAsync(Route entity)
    {
        throw new NotImplementedException();
    }

    public Task<Route> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Route>> ListAsync()
    {
        using var dbContext = new ApplicationContext();
        return await dbContext.Routes.ToListAsync();
    }
}