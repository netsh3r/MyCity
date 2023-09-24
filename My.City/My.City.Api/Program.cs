using My.City.Abstraction.Dal.Repository;
using My.City.Abstraction.Domain.Entity;
using My.City.Api.Application;
using My.City.Api.Application.Database;
using My.City.Api.Application.WebHost;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Map;
using Business.Service.Location;
using Business.Service.Route;
using Business.Service.RoutePoints;
using My.City.Dal;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsAllowAll",
        builder =>
        {
            //TODO: change origins after create front project
            builder
                .WithOrigins(
                    "http://localhost:3000",
                    "http://localhost:3030",
                    "https://localhost:3030",
                    "https://netsh3r.github.io")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .WithExposedHeaders("Content-Disposition");
        });
});
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IRouteService, RouteService>();
builder.Services.AddScoped<IRoutePointService, RoutePointService>();
builder.Services.AddPostgreSql<MyCityContext>(builder.Configuration);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
var assemblies = AssembliesExtension.GetAssemblies(builder.Configuration).Distinct().ToArray();
builder.Host.ConfigureContainer<ContainerBuilder>(b => b.RegisterDbServices(assemblies));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsAllowAll");

app.MapControllers();

app.Run();