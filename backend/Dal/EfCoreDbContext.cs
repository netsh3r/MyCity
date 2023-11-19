using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;

namespace Dal;

public abstract class EfCoreDbContext : DbContext
{
    private readonly DbContextSettings _contextSettings;

    protected EfCoreDbContext(DbContextOptions options, IOptionsSnapshot<DbContextSettings> contextSettings) :
        base(options)
    {
        _contextSettings = contextSettings.Value;
        ChangeTracker.CascadeDeleteTiming = CascadeTiming.OnSaveChanges;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging(_contextSettings.IsEnabledSensitiveDataLogging);
        base.OnConfiguring(optionsBuilder);
    }
}