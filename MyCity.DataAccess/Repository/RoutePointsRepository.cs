using Microsoft.EntityFrameworkCore;
using MyCity.Core.Repository;
using MyCity.DataAccess.Entities;

namespace MyCity.DataAccess.Repository
{
    public class RoutePointsRepository : IRepository<RoutePoints>
    {
        private readonly ApplicationContext _db;

        public RoutePointsRepository(ApplicationContext db)
        {
            _db = db;
        }
        public async Task<RoutePoints> CreateAsync(RoutePoints routePoint)
        {
            await _db.RoutePoints.AddAsync(routePoint);
            await _db.SaveChangesAsync();
            return routePoint;
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await _db.RoutePoints.FindAsync(id);

            if (entity == null)
                return;

            _db.RoutePoints.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<RoutePoints> GetAsync(long id)
        {
            return await _db.RoutePoints.FindAsync(id);
        }

        public async Task<IEnumerable<RoutePoints>> ListAsync()
        {
            return await _db.RoutePoints.ToListAsync();
        }

        public DbSet<RoutePoints> GetAll()
        {
            return _db.RoutePoints;
        }

        public async Task<RoutePoints> UpdateAsync(RoutePoints routePoint)
        {
            _db.RoutePoints.Entry(routePoint).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return routePoint;
        }
    }
}
