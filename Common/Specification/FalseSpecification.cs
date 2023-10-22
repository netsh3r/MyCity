using System.Linq.Expressions;

namespace Common.Specification;

public class FalseSpecification<T> : ExpressionSpecification<T>
{
    protected internal FalseSpecification() : base(_ => false)
    {
    }
}