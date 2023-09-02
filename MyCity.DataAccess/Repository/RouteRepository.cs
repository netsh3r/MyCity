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

    public async Task<Route> UpdateAsync(Route route)
    {
        using var dbContext = new ApplicationContext();
        dbContext.Routes.Entry(route).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();
        return route;
    }

    public async Task<Route> GetAsync(long id)
    {
        using var dbContext = new ApplicationContext();
        return await dbContext.Routes.FindAsync(id);
    }

    public async Task DeleteAsync(long id)
    {
        using var dbContext = new ApplicationContext();
        var entity = await dbContext.Routes.FindAsync(id);

        if (entity == null)
            return;

        dbContext.Routes.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Route>> ListAsync()
    {
        return await _db.Routes.ToListAsync();
    }
}