using Microsoft.EntityFrameworkCore;
using MyCity.DataAccess.Entities;

namespace MyCity.DataAccess;

public class ApplicationContext : DbContext
{
    public DbSet<Route> Routes { get; set; }
    public DbSet<RoutePoints> RoutePoints { get; set; }
    public DbSet<Point> Points { get; set; }
    public DbSet<Location> Locations { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>()
            .Property(x => x.LocationType)
            .HasConversion<int>();
    }
}