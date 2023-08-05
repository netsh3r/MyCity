using Microsoft.EntityFrameworkCore;
using MyCity.DataAccess.Entities;

namespace MyCity.DataAccess;

public class ApplicationContext : DbContext
{
    public DbSet<Route> Routes { get; set; }
    public DbSet<RoutePoints> RoutePoints { get; set; }
    public DbSet<Point> Points { get; set; }
    public DbSet<Location> Locations { get; set; }
    public ApplicationContext() => Database.EnsureCreated();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MyCity;User ID=postgres;Password=123;Timeout=1024;CommandTimeout=1024;MinPoolSize=0;MaxPoolSize=64;MaxAutoPrepare=256;AutoPrepareMinUsages=3;ReadBufferSize=16384;WriteBufferSize=16384;ConnectionPruningInterval=5;ConnectionIdleLifetime=15;");
    }
}