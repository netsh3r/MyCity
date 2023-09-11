using Microsoft.Extensions.DependencyInjection;
using MyCity.Core.Repository;
using MyCity.DataAccess.Entities;
using MyCity.DataAccess.Repository;

namespace MyCity.DataAccess;

/// <summary>
///     Класс для регистрации зависимости
/// </summary>
public static class Modules
{
    /// <summary>
    ///     Метод регистрации зависимости
    /// </summary>
    public static IServiceCollection AddDependencyGroup(IServiceCollection services)
    {
        services.AddScoped<IRepository<Route>, RouteRepository>();
        services.AddScoped<IRepository<RoutePoints>, RoutePointsRepository>();
        services.AddScoped<IRepository<Location>, LocationRepository>();
        return services;
    }
}