using System.Linq.Expressions;
using JetBrains.Annotations;

namespace My.City.Common.Specification;

[PublicAPI]
public class ExpressionSpecification<T> : Specification<T>
{
    private readonly Expression<Func<T, bool>> _predicate;

    protected internal ExpressionSpecification(Expression<Func<T, bool>> predicate)
    {
        _predicate = predicate;
    }

    protected override Expression<Func<T, bool>> ToExpression() => _predicate;
}
