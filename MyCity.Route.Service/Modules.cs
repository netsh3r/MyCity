﻿using MyCity.Core.Services;
using MyCity.Route.Service.Services;

namespace MyCity.Route.Service;

using Microsoft.Extensions.DependencyInjection;
public static class Modules
{
    public static IServiceCollection AddDependencyGroup(this IServiceCollection services)
    {
        services.AddScoped<IRouteService, RouteService>();
        return services;
    }
}