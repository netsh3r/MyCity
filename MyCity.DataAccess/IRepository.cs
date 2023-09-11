using Microsoft.EntityFrameworkCore;
using MyCity.DataAccess.Entities;

namespace MyCity.Core.Repository;

public interface IRepository<T> where T: BaseEntity
{
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T?> GetAsync(long id);
    Task DeleteAsync(long id);
    Task<IEnumerable<T>> ListAsync();

    DbSet<T> GetAll();
}