using Microsoft.EntityFrameworkCore.Metadata.Builders;
using My.City.Core.Models;

namespace My.City.Dal.EntityConfiguration;

public class RoutePointsConfiguration: BaseEntityConfiguration<RoutePoints, long>
{
    public override void Configure(EntityTypeBuilder<RoutePoints> builder)
    {
        builder.Property(e => e.RouteId)
            .IsRequired();
        builder.Property(e => e.RoutePointsObj)
            .IsRequired();
        base.Configure(builder);
    }
}