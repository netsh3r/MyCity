namespace MyCity.Event.Service
{
    using Microsoft.Extensions.DependencyInjection;
    using MyCity.Core.Services;
    using MyCity.Event.Service.Services;

    public static class Modules
    {
        public static IServiceCollection AddDependencyGroup(this IServiceCollection services)
        {
            services.AddScoped<IEventService, EventService>();
            return services;
        }
    }
}
