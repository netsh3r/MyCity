namespace MyCity
{
    using Services;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddDependencyGroup();
            builder.WebHost.UseUrls();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsAllowAll",
                    builder =>
                    {
                        //TODO: change origins after create fron project
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

            app.UseCors("CorsAllowAll");
            app.UseHttpsRedirection();

            // app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}