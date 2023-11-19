using System.Linq.Expressions;

namespace Common.Specification;

internal class OrSpecification<T> : ComposeSpecification<T>
{
    public OrSpecification(Specification<T> first, Specification<T> second) : base(Expression.OrElse, first, second)
    {
    }
}
