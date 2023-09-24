using System.Text.Json;
using Business.Model.RoutePoints;
using My.City.Abstraction.Dal.Repository;
using My.City.Common.Specification;

namespace Business.Service.RoutePoints;

public class RoutePointService : IRoutePointService
{
    private readonly ICommandRepository<My.City.Core.Models.RoutePoints> _commandRepository;

    public RoutePointService(ICommandRepository<My.City.Core.Models.RoutePoints> commandRepository)
    {
        _commandRepository = commandRepository;
    }

    public async Task<RoutePointDto> GetAsync(long routeId)
    {
        var result = await _commandRepository.GetFirstAsync(
            new ExpressionSpecification<My.City.Core.Models.RoutePoints>(
                x => x.RouteId == routeId));
        return JsonSerializer.Deserialize<RoutePointDto>(result.RoutePointsObj);
    }

    public async Task<RoutePointDto> CreateOrUpdateAsync(long routeId, RoutePointDto dto)
    {
        if (routeId == null)
        {
            await _commandRepository.AddAsync(new My.City.Core.Models.RoutePoints()
            {
                RouteId = routeId,
                RoutePointsObj = JsonSerializer.Serialize(dto)
            });
        }
        else
        {
            var result = await _commandRepository.GetFirstAsync(
                new ExpressionSpecification<My.City.Core.Models.RoutePoints>(
                    x => x.RouteId == routeId));
            result.RoutePointsObj = JsonSerializer.Serialize(dto);
            _commandRepository.Update(result);
        }

        return dto;
    }
}