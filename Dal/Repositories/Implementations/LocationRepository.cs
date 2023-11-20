using Dal.Converter;
using Dto.Dal;

namespace Dal.Repositories.Implementations;

public class LocationRepository: AbstractRepository<Location, long, Entities.Location>, ILocationRepository
{
    public LocationRepository(EfCoreDbContext context, IConverter<Location, long, Entities.Location> converter) : base(context, converter)
    {
    }
}