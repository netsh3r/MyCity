using System.Linq.Expressions;

namespace My.City.Common.Specification;

public class FalseSpecification<T> : ExpressionSpecification<T>
{
    protected internal FalseSpecification() : base(_ => false)
    {
    }
}