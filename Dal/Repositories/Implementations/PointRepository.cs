using Dal.Converter;
using Dto.Dal;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories.Implementations;

public class PointRepository: AbstractRepository<Point, long, Entities.Point>, IPointRepository
{
    public PointRepository(EfCoreDbContext context, IConverter<Point, long, Entities.Point> converter) : base(context, converter)
    {
    }
}