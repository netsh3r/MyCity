using System.Text.Json;
using Business.Model.RoutePoints;
using Common.Specification;
using Dal.Repositories;
using Dto.Dal;

namespace Business.Service.RoutePoints;

public class RoutePointService : IRoutePointService
{
    private readonly IRoutePointRepository _routePointRepository;

    public RoutePointService(IRoutePointRepository routePointRepository)
    {
        _routePointRepository = routePointRepository;
    }

    public async Task<RoutePointDto[]> GetAsync(long routeId)
    {
        var result = await _routePointRepository.GetByRouteIdAsync(routeId);
        return JsonSerializer.Deserialize<RoutePointDto[]>(result.RoutePointObj);
    }

    public async Task<RoutePointDto[]> CreateOrUpdateAsync(long routeId, RoutePointDto[] dto)
    {
        if (routeId == null)
        {
            await _routePointRepository.AddAsync(new ()
            {
                RouteId = routeId,
                RoutePointObj = JsonSerializer.Serialize(dto)
            });
        }
        else
        {
            var result = await _routePointRepository.GetByRouteIdAsync(routeId) ?? new RoutePoint
            {
                RouteId = routeId
            };
            result.RoutePointObj = JsonSerializer.Serialize(dto);
            
            _routePointRepository.AddOrUpdateAsync(result);
        }

        return dto;
    }
}