using Business.Model.Route;

namespace Business.Service.Route;

public interface IRouteService
{
    Task<IReadOnlyCollection<RouteListDto>> ListAsync();
    Task<RouteDto> CreateOrUpdateAsync(RouteDto dto);
    void Delete(long id);
    Task<RouteDto> GetAsync(long id);
}