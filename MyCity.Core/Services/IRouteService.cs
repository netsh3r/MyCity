using MyCity.DataAccess.Entities;

namespace MyCity.Core.Services;

public interface IRouteService
{
    Task<Route> CrateAsync(Route route);
    Task<Route> UpdateAsync(Route route);
    Task DeleteAsync(long id);
    Task<Route> GetAsync(long id);
}