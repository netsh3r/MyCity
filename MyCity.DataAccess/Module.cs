using Microsoft.Extensions.DependencyInjection;
using MyCity.Core.Repository;
using MyCity.DataAccess.Entities;
using MyCity.DataAccess.Repository;

namespace MyCity.DataAccess;

public static class Modules
{
    public static IServiceCollection AddDependencyGroup(IServiceCollection services)
    {
        services.AddSingleton<IRepository<Route>, RouteRepository>();
        return services;
    }
}