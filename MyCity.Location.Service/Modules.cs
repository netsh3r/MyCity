namespace MyCity.Route.Service;

using Microsoft.Extensions.DependencyInjection;

/// <summary>
///     Класс для регистрации зависимости
/// </summary>
public static class Modules
{
    /// <summary>
    ///     Метод регистрации зависимости
    /// </summary>
    public static IServiceCollection AddDependencyGroup(this IServiceCollection services)
    {
        return services;
    }
}