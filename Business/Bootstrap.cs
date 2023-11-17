using Business.Converters;
using Business.Converters.Implementations;
using Business.Service;
using Business.Service.Location;
using Business.Service.Route;
using Business.Service.RoutePoints;
using Microsoft.Extensions.DependencyInjection;

namespace Business;

public static class Bootstrap
{
    public static IServiceCollection AddBusinessDependencies(this IServiceCollection service)
    {
        service.AddScoped<ILocationService, LocationService>();
        service.AddScoped<IRouteService, RouteService>();
        service.AddScoped<IRoutePointService, RoutePointService>();
        service.AddSingleton<ILocationConverters, LocationConverters>();
        service.AddSingleton<IPointConverters, PointConverters>();
        service.AddSingleton<IRouteConverters, RouteConverters>();
        service.AddSingleton<Test, Test>();
        return service;
    }
}