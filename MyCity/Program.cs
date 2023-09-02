using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using MyCity.DataAccess;

namespace MyCity
{
    public class Program
    {
        // TODO
        // Maybe rewrite to .net6 style? 
        // How take from json some section? 
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder();

            var connectionString = builder.Configuration.GetConnectionString("DB:NpgSql");
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connectionString));

            DataAccess.Modules.AddDependencyGroup(builder.Services);
            Route.Modules.AddDependencyGroup(builder.Services);

            builder.WebHost.UseUrls();
            builder.Services.AddControllers();
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

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("CorsAllowAll");
            app.UseHttpsRedirection();

            //app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}