using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using My.City.Core.Models;

namespace My.City.Dal.EntityConfiguration;

public class LocationConfiguration: BaseEntityConfiguration<Location, long>
{
    public override void Configure(EntityTypeBuilder<Location> builder)
    {
        base.Configure(builder);
        builder.ToTable("Location");
        builder.Property(e => e.Name)
            .IsRequired();
        builder.Property(e => e.Description)
            .IsRequired();
        builder.Property(e => e.WorkTimeEnd)
            .IsRequired();
        builder.Property(e => e.WorkTimeStart)
            .IsRequired();
        builder.Property(e => e.LocationType)
            .IsRequired();
        builder.Property(e => e.Description)
            .IsRequired();
        builder.Property(e => e.Image)
            .IsRequired();
    }
}