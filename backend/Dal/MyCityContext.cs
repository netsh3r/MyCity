using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Dal;

public class MyCityContext: EfCoreDbContext
{
    public MyCityContext(DbContextOptions options, IOptionsSnapshot<DbContextSettings> contextSettings) : base(options, contextSettings)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(MyCityDbContextConstants.Schema);

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyCityContext).Assembly);
    }
}