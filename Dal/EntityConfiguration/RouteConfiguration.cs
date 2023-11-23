using Dal.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.EntityConfiguration;

public class RouteConfiguration: BaseEntityConfiguration<Route, long>
{
    public override void Configure(EntityTypeBuilder<Route> builder)
    {
        builder.Property(e => e.NameRoute)
            .IsRequired();
        builder.Property(e => e.Description)
            .IsRequired();
        base.Configure(builder);
    }
}