using Dal.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.EntityConfiguration;

public class RoutePointsConfiguration: BaseEntityConfiguration<RoutePoint, long>
{
    public override void Configure(EntityTypeBuilder<RoutePoint> builder)
    {
        builder.Property(e => e.RouteId)
            .IsRequired();
        builder.Property(e => e.RoutePointObj)
            .IsRequired();
        base.Configure(builder);
    }
}