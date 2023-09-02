using Microsoft.EntityFrameworkCore;
using MyCity.Core.Repository;
using MyCity.DataAccess.Entities;

namespace MyCity.DataAccess.Repository;

/// <summary>
///     Репозиторий маршрута
/// </summary>
public class RouteRepository : IRepository<Route>
{
    private readonly ApplicationContext _db;

    public RouteRepository(ApplicationContext db)
    {
        _db = db;
    }

    public async Task<Route> CreateAsync(Route route)
    {
        await _db.AddAsync(route);
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
        return await _db.Routes.ToListAsync();
    }
}