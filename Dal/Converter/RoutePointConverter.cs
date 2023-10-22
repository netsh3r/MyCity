using Dto.Dal;

namespace Dal.Converter;

public class RoutePointConverter : IConverter<RoutePoint, long, Entities.RoutePoint>
{
    public RoutePoint Convert(Entities.RoutePoint entity)
        => new()
        {
            Id = entity.Id,
            Route = new()
            {
                Id = entity.Route.Id,
                Name = entity.Route.Name,
                Description = entity.Route.Description,
            },
            RouteId = entity.RouteId,
            RoutePointObj = entity.RoutePointObj,
        };

    public Entities.RoutePoint Convert(RoutePoint model)
        => new()
        {
            Id = model.Id ?? 0,
            Route = new()
            {
                Id = model.Route.Id ?? 0,
                Name = model.Route.Name,
                Description = model.Route.Description,
            },
            RouteId = model.RouteId,
            RoutePointObj = model.RoutePointObj,
        };
}