namespace MyCity.Route.Service;

using Microsoft.Extensions.DependencyInjection;

public static class Modules
{
    /// <summary>
    ///     Метод, позволяющий подтягивать зависимость сервиса в DI
    /// </summary>
    public static IServiceCollection AddDependencyGroup(this IServiceCollection services)
    {
        return services;
    }
}