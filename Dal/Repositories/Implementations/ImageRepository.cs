using Dal.Converter;
using Dto.Dal;

namespace Dal.Repositories.Implementations;

public class ImageRepository : AbstractRepository<Image, long, Entities.Image>, IImageRepository
{
    public ImageRepository(EfCoreDbContext context, IConverter<Image, long, Entities.Image> converter) : base(context, converter)
    {
    }
}

