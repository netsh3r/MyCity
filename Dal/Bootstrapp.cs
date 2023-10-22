using Dal.Converter;
using Dal.Repositories;
using Dal.Repositories.Implementations;
using Dto.Dal;
using Microsoft.Extensions.DependencyInjection;

namespace Dal;

public static class Bootstrapp
{
    public static IServiceCollection AddDalDependencies(this IServiceCollection service)
    {
        service.AddSingleton<IConverter<Location, long, Entities.Location>, LocationConverter>();
        service.AddSingleton<IConverter<Route, long, Entities.Route>, RouteConverter>();
        service.AddSingleton<IConverter<Point, long, Entities.Point>, PointConverter>();
        service.AddSingleton<IConverter<RoutePoint, long, Entities.RoutePoint>, RoutePointConverter>();
        service.AddSingleton<ILocationRepository, LocationRepository>();
        service.AddSingleton<IRouteRepository, RouteRepository>();
        service.AddSingleton<IRoutePointRepository, RoutePointRepository>();
        service.AddSingleton<IPointRepository, PointRepository>();
        return service;
    }
}