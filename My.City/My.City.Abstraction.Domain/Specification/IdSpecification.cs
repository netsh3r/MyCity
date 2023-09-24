using My.City.Abstraction.Domain.Entity;
using My.City.Common.Specification;

namespace My.City.Abstraction.Domain.Specification;

public class IdSpecification<TEntity, TPrimaryKey> : ExpressionSpecification<TEntity>
    where TEntity : class, IEntity<TPrimaryKey>
{
    public IdSpecification(TPrimaryKey id) : base(e => Equals(e.Id, id))
    {

    }
}

