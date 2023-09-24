using System.Reflection;
using My.City.Abstraction.Dal.Repository;
using Autofac;
using My.City.Common.Extension;
using My.City.Dal;
using My.City.Dal.AbstractRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace My.City.Api.Application.Database;

public static class DbBootstrapper
{
    public static IServiceCollection AddPostgreSql<TContext>(this IServiceCollection services,
        IConfiguration configuration)
        where TContext : EfCoreDbContext
    {
        var dbSettings = services.ConfigureSettings<DatabaseSettings>(configuration);
        services.ConfigureSettings<DbContextSettings>(configuration);
        services.AddDbContext<TContext>((provider, options) =>
        {
            options.UseNpgsql(
                dbSettings.ConnectionString,
                optionsBuilder => optionsBuilder.MigrationsHistoryTable(MyCityDbContextConstants.MigrationsHistoryTable,
                    MyCityDbContextConstants.Schema));
            var interceptor = provider.GetServices<IInterceptor>().ToArray();
            if (interceptor.Any())
            {
                options.AddInterceptors(interceptor);
            }
        });
        services.AddScoped<EfCoreDbContext>(provider => provider.GetRequiredService<TContext>());
        return services;
    }
    
    internal static void RegisterRepositories(this ContainerBuilder builder, params Assembly[] assemblies)
    {
        var contractTypes = new[]
        {
            typeof(IReadRepository<>),
            typeof(IQueryRepository<>),
            typeof(ICommandRepository<>),

            typeof(IReadRepository<,>),
            typeof(IQueryRepository<,>),
            typeof(ICommandRepository<,>)
        };

        foreach (var contractType in contractTypes)
        {
            builder.RegisterAssemblyTypes(assemblies)
                .Where(type => !type.IsGenericType && type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == contractType))
                .AsImplementedInterfaces()
                .InstancePerDependency();

            var genericTypes = assemblies
                .SelectMany(x => x.GetTypes())
                .Where(type => type is { IsGenericType: true, IsClass: true, IsAbstract: false } && type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == contractType))
                .ToList();

            foreach (var genericType in genericTypes)
            {
                builder.RegisterGeneric(genericType).As(contractType).InstancePerDependency();
            }
        }
    }
}