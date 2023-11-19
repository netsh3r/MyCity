using Dto.Dal;

namespace Dal.Converter;

public class RoutePointConverter : IConverter<RoutePoint, long, Entities.RoutePoint>
{
    public RoutePoint? Convert(Entities.RoutePoint? entity)
        => entity is not null ? new()
        {
            Id = entity.Id,
            RouteId = entity.RouteId,
            RoutePointObj = entity.RoutePointObj,
        } : null;

    public Entities.RoutePoint Convert(RoutePoint model)
        => new()
        {
            Id = model.Id ?? 0,
            RouteId = model.RouteId,
            RoutePointObj = model.RoutePointObj,
        };
}