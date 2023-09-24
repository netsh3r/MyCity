using System.Reflection;
using My.City.Api.Application.Database;
using My.City.Api.Application.WebHost;
using Autofac;

namespace My.City.Api.Application;

public static class AutofacConfig
{
    public static void RegisterDbServices(this ContainerBuilder builder, params Assembly[] assemblies)
    {
        builder.RegisterRepositories(assemblies);
    }
}