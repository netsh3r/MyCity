using Microsoft.EntityFrameworkCore;
using MyCity.Core.Repository;
using MyCity.DataAccess.Entities;

namespace MyCity.DataAccess.Repository
{
    public class RoutePointsRepository : IRepository<RoutePoints>
    {
        public async Task<RoutePoints> CreateAsync(RoutePoints routePoint)
        {
            using var dbContext = new ApplicationContext();
            await dbContext.RoutePoints.AddAsync(routePoint);
            return routePoint;
        }

        public async Task DeleteAsync(long id)
        {
            using var dbContext = new ApplicationContext();
            var entity = await dbContext.RoutePoints.FindAsync(id);

            if (entity == null)
                return;

            dbContext.RoutePoints.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<RoutePoints> GetAsync(long id)
        {
            using var dbContext = new ApplicationContext();
            return await dbContext.RoutePoints.FindAsync(id);
        }

        public async Task<IEnumerable<RoutePoints>> ListAsync()
        {
            using var dbContext = new ApplicationContext();
            return await dbContext.RoutePoints.ToListAsync();
        }

        public async Task<RoutePoints> UpdateAsync(RoutePoints routePoint)
        {
            using var dbContext = new ApplicationContext();
            dbContext.RoutePoints.Entry(routePoint).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return routePoint;
        }
    }
}
