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
        await _db.AddRangeAsync(route);
        await _db.SaveChangesAsync();
        return route;
    }

    public async Task<Route> UpdateAsync(Route route)
    {
        _db.Routes.Entry(route).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return route;
    }

    public async Task<Route?> GetAsync(long id)
    {
        return await _db.Routes.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task DeleteAsync(long id)
    {
        var entity = await _db.Routes.FindAsync(id);

        if (entity == null)
            return;

        _db.Routes.Remove(entity);
        await _db.SaveChangesAsync();
    }

    public async Task<IEnumerable<Route>> ListAsync()
    {
        return await _db.Routes.ToListAsync();
    }

    public DbSet<Route> GetAll()
    {
        return _db.Routes;
    }
}