using Dal.Entities;

namespace Common.Specification;

public class IdSpecification<TEntity, TPrimaryKey> : ExpressionSpecification<TEntity>
    where TEntity : class, IEntity<TPrimaryKey>
{
    public IdSpecification(TPrimaryKey id) : base(e => Equals(e.Id, id))
    {

    }
}

