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
    ///     Необходим для регистрации репозиториев в инфрастркутрных файлах проекта
    /// </summary>
    public static IServiceCollection AddDependencyGroup(IServiceCollection services)
    {
        services.AddSingleton<IRepository<Route>, RouteRepository>();
        return services;
    }
}