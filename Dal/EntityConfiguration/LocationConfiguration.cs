using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.EntityConfiguration;

public class LocationConfiguration : BaseEntityConfiguration<Location, long>
{
    public override void Configure(EntityTypeBuilder<Location> builder)
    {
        base.Configure(builder);
        builder.ToTable("Location");
        builder.Property(e => e.Name)
            .IsRequired();
        builder.Property(e => e.Description)
            .IsRequired();
        builder.HasOne(x => x.Point)
            .WithOne()
            .HasForeignKey<Location>(x => x.PointId)
            .IsRequired();
    }
}