using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using My.City.Abstraction.Domain.Entity;

namespace My.City.Dal.EntityConfiguration;

public abstract class BaseEntityConfiguration<TEntity, TPrimaryKey> : IEntityTypeConfiguration<TEntity>
    where TEntity : class, IEntity<TPrimaryKey>
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(e => e.Id);
    }
}