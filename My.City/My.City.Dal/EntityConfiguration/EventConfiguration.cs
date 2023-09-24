using Microsoft.EntityFrameworkCore.Metadata.Builders;
using My.City.Core.Models;

namespace My.City.Dal.EntityConfiguration;

public class EventConfiguration: BaseEntityConfiguration<Event, long>
{
    public override void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.Property(e => e.Name)
            .IsRequired();
        builder.Property(e => e.Description)
            .IsRequired();
        builder.Property(e => e.DateEnd)
            .IsRequired();
        builder.Property(e => e.DateStart)
            .IsRequired();
        base.Configure(builder);
    }
}