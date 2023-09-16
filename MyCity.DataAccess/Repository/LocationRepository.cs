using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyCity.Core.Repository;
using MyCity.DataAccess.Entities;

namespace MyCity.DataAccess.Repository;

/// <summary>
///     Репозиторий локаций
/// </summary>
public class LocationRepository : IRepository<Location>
{
    private readonly ApplicationContext _db;

    public LocationRepository(ApplicationContext db)
    {
        _db = db;
    }
    
    public async Task<Location> CreateAsync(Location entity)
    {
        await _db.Locations.AddAsync(entity);
        await _db.SaveChangesAsync();

        return entity;
    }

    public async Task<Location> UpdateAsync(Location location)
    {
        _db.Attach(location);
        _db.Locations.Entry(location).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return location;
    }

    public async Task<Location?> GetAsync(long id)
    {
        return await _db.Locations.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task DeleteAsync(long id)
    {
        var location = await GetAsync(id);
        _db.Locations.Remove(location);
        await _db.SaveChangesAsync();
    }

    public async Task<IEnumerable<Location>> ListAsync()
    {
        return await _db.Locations.ToListAsync();
    }
    
    public DbSet<Location> GetAll()
    {
        return _db.Locations;
    }
}