namespace MyCity.Location
{
    using MyCity.Core.Services;
    using MyCity.Location.Services;
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
            services.AddScoped<ILocationService, LocationService>();
            return services;
        }
    }
}

