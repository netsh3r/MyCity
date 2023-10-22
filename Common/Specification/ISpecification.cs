namespace Common.Specification;

public interface ISpecification<in T>
{
    bool IsSatisfiedBy(T entity);
}
