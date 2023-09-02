using Microsoft.EntityFrameworkCore;
using MyCity.DataAccess;
using MyCity.Route;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DB:NpgSql");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connectionString));

MyCity.DataAccess.Modules.AddDependencyGroup(builder.Services);
MyCity.Route.Modules.AddDependencyGroup(builder.Services);

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

//app.UseAuthorization();

app.MapControllers();

app.Run();


