using Dal.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.EntityConfiguration;

public class ImageConfiguration : BaseEntityConfiguration<Image, long>
{
    public override void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.Property(e => e.Name)
            .IsRequired();
        builder.Property(e => e.Source)
            .IsRequired();
        base.Configure(builder);
    }
}

