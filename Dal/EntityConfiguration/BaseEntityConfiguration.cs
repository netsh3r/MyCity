using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.EntityConfiguration;

public abstract class BaseEntityConfiguration<TEntity, TPrimaryKey> : IEntityTypeConfiguration<TEntity>
    where TEntity : class, IEntity<TPrimaryKey>
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(e => e.Id);
    }
}