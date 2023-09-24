using Microsoft.EntityFrameworkCore.Metadata.Builders;
using My.City.Core.Models;

namespace My.City.Dal.EntityConfiguration;

public class PointConfiguration: BaseEntityConfiguration<Point, long>
{
    public override void Configure(EntityTypeBuilder<Point> builder)
    {
        builder.Property(e => e.X)
            .IsRequired();
        builder.Property(e => e.Y)
            .IsRequired();
        base.Configure(builder);
    }
}