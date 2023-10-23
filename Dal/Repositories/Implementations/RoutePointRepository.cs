using Dal.Converter;
using Dto.Dal;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories.Implementations;

public class RoutePointRepository: AbstractRepository<RoutePoint, long, Entities.RoutePoint>, IRoutePointRepository
{
    public RoutePointRepository(EfCoreDbContext context, IConverter<RoutePoint, long, Entities.RoutePoint> converter) : base(context, converter)
    {
    }

    public async Task<RoutePoint?> GetByRouteIdAsync(long RouteId)
    {
        var result = await DbSet.FirstOrDefaultAsync(x => x.RouteId == RouteId);
        return _converter.Convert(result);
    }
}