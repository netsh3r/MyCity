using JetBrains.Annotations;

namespace My.City.Common.Specification;

[PublicAPI]
public interface ISpecification<in T>
{
    bool IsSatisfiedBy(T entity);
}
