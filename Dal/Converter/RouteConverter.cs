using Dto.Dal;

namespace Dal.Converter;

public class RouteConverter : IConverter<Route, long, Entities.Route>
{
    public Route Convert(Entities.Route entity)
        => new()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description
        };

    public Entities.Route Convert(Route model)
        => new()
        {
            Id = model.Id ?? 0,
            Name = model.Name,
            Description = model.Description
        };
}