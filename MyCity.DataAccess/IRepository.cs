using MyCity.DataAccess.Entities;

namespace MyCity.Core.Repository;

public interface IRepository<T> where T: new()
{
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> GetAsync(long id);
    Task DeleteAsync(long id);
    Task<IEnumerable<Route>> ListAsync();
}