namespace Services
{
    using Microsoft.Extensions.DependencyInjection;
    using TestServices;
    public static class Modules
    {
        public static IServiceCollection AddDependencyGroup(IServiceCollection services)
        {
            services.AddScoped<TestService>();
            return services;
        }
    }
}