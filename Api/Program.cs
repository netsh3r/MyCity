// using Api.Application.Database;
// using Autofac.Extensions.DependencyInjection;
// using Business;
// using Dal;
//
// var builder = WebApplication.CreateBuilder(args);
//
// builder.WebHost.UseUrls();
// builder.Services.AddControllers().AddNewtonsoftJson();
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
// builder.Services.AddDalDependencies();
// builder.Services.AddBusinessDependencies();
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("CorsAllowAll",
//         builder =>
//         {
//             //TODO: change origins after create front project
//             builder
//                 .WithOrigins(
//                     "http://localhost:3000",
//                     "http://localhost:3030",
//                     "https://localhost:3030",
//                     "https://netsh3r.github.io")
//                 .AllowAnyMethod()
//                 .AllowAnyHeader()
//                 .AllowCredentials()
//                 .WithExposedHeaders("Content-Disposition");
//         });
// });
// builder.Services.AddPostgreSql<MyCityContext>(builder.Configuration);
// builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
// var app = builder.Build();
//
// if (app.Environment.IsDevelopment())
// {
//     
// }
//
// app.UseSwagger();
// app.UseSwaggerUI();
//
// app.UseHttpsRedirection();
// app.UseCors("CorsAllowAll");
//
// app.MapControllers();
//
// app.Run();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();