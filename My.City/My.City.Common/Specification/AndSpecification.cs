using System.Linq.Expressions;

namespace My.City.Common.Specification;

internal class AndSpecification<T> : ComposeSpecification<T>
{
    public AndSpecification(Specification<T> first, Specification<T> second) : base(Expression.AndAlso, first, second)
    {
    }
}
