
using Dto.Dal;

namespace Dal.Repositories;

public interface IRoutePointRepository : IRepository<RoutePoint, long>
{
    Task<RoutePoint> GetByRouteIdAsync(long RouteId);
}