using Business.Converters;
using Business.Model.Route;
using Business.Service.RoutePoints;
using Dal.Repositories;

namespace Business.Service.Route;

public class RouteService : IRouteService
{
    private readonly IRouteRepository _routeRepository;
    private readonly IRouteConverters _routeConverters;
    private readonly IRoutePointService _routePointService;

    public RouteService(IRouteRepository routeRepository, IRouteConverters routeConverters, IRoutePointService routePointService)
    {
        _routeRepository = routeRepository;
        _routeConverters = routeConverters;
        _routePointService = routePointService;
    }

    public async Task<IReadOnlyCollection<RouteListDto>> ListAsync()
    {
        return (await _routeRepository.GetAllAsync()).Select(x => new RouteListDto
        {
            Name = x.Name,
            Description = x.Description,
            Id = x.Id
        }).ToArray();
    }

    public async Task<RouteDto> CreateOrUpdateAsync(RouteDto dto)
    {
        var result = await _routeRepository.AddOrUpdateAsync(_routeConverters.Convert(dto));
        dto.Id = result.Id;
        await _routePointService.CreateOrUpdateAsync(dto.Id.Value, dto.RoutePointDto);
        return dto;
    }

    public Task Delete(long id)
        => _routeRepository.Delete(id);

    public async Task<RouteDto> GetAsync(long id)
    {
        var result = await _routeRepository.GetByIdAsync(id);
        var route = _routeConverters.Convert(result);
        route.RoutePointDto = await _routePointService.GetAsync(id);
        return route;
    }
}