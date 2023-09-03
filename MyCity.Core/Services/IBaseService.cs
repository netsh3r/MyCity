namespace MyCity.Core.Services;

public interface IBaseService<T, TDto> 
    where T: new() 
    where TDto : new()
{
    Task<IEnumerable<T>> ListAsync();
    Task<T> CrateAsync(TDto locationDto);
    Task<T> UpdateAsync(TDto dto);
    Task DeleteAsync(long id);
    Task<T> GetAsync(long id);
}