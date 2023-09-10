﻿using Microsoft.EntityFrameworkCore;
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
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MyCity;User ID=postgres;Password=postgres;Timeout=1024;CommandTimeout=1024;MinPoolSize=0;MaxPoolSize=64;MaxAutoPrepare=256;AutoPrepareMinUsages=3;ReadBufferSize=16384;WriteBufferSize=16384;ConnectionPruningInterval=5;ConnectionIdleLifetime=15;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>()
            .Property(x => x.LocationType)
            .HasConversion<int>();
    }
}