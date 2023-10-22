using Dal.Converter;
using Dto.Dal;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories.Implementations;

public class RouteRepository: AbstractRepository<Route, long, Entities.Route>, IRouteRepository
{
    public RouteRepository(EfCoreDbContext context, IConverter<Route, long, Entities.Route> converter) : base(context, converter)
    {
    }
}