using Microsoft.EntityFrameworkCore;
using MyCity.Core.Repository;
using MyCity.DataAccess.Entities;

namespace MyCity.DataAccess.Repository;

public class RouteRepository : IRepository<Route>
{
    public async Task<Route> CreateAsync(Route route)
    {
        using var dbContext = new ApplicationContext();
        await dbContext.AddAsync(route);
        return route;
    }

    public async Task<Route> UpdateAsync(Route entity)
    {
        using var dbContext = new ApplicationContext();
        dbContext.Routes.Entry(entity).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();
        return entity;
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
        using var dbContext = new ApplicationContext();
        return await dbContext.Routes.ToListAsync();
    }
}