using Microsoft.EntityFrameworkCore.Metadata.Builders;
using My.City.Core.Models;

namespace My.City.Dal.EntityConfiguration;

public class RouteConfiguration: BaseEntityConfiguration<Route, long>
{
    public override void Configure(EntityTypeBuilder<Route> builder)
    {
        builder.Property(e => e.Name)
            .IsRequired();
        builder.Property(e => e.Description)
            .IsRequired();
        builder.Property(e => e.Length)
            .IsRequired();
        base.Configure(builder);
    }
}