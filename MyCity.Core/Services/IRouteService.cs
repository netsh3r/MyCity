using MyCity.Core.Models;
using MyCity.DataAccess.Entities;

namespace MyCity.Core.Services;

public interface IRouteService
{
    Task<IEnumerable<Route>> ListAsync();
    Task<Route> CrateAsync(RouteDto dto);
    Task<Route> UpdateAsync(RouteDto dto);
    Task DeleteAsync(long id);
    Task<Route> GetAsync(long id);
}