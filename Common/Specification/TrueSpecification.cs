namespace Common.Specification;

public class TrueSpecification<T> : ExpressionSpecification<T>
{
    public TrueSpecification() : base(_ => true)
    {

    }
}