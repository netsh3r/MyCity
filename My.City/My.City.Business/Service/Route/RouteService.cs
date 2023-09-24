using AutoMapper;
using Business.Model.Route;
using Business.Service.RoutePoints;
using My.City.Abstraction.Dal.Repository;
using My.City.Common.Specification;

namespace Business.Service.Route;

public class RouteService : IRouteService
{
    private readonly ICommandRepository<My.City.Core.Models.Route> _commandRouteRepository;
    private readonly IRoutePointService _routePointService;
    private readonly IMapper _mapper;

    public RouteService(ICommandRepository<My.City.Core.Models.Route> commandRouteRepository, IMapper mapper, IRoutePointService routePointService)
    {
        _commandRouteRepository = commandRouteRepository;
        _mapper = mapper;
        _routePointService = routePointService;
    }

    public async Task<IReadOnlyCollection<RouteListDto>> ListAsync()
    {
        return (await _commandRouteRepository.GetAllAsync()).Select(x => new RouteListDto
        {
            Name = x.Name,
            Description = x.Description,
            Id = x.Id
        }).ToArray();
    }

    public async Task<RouteDto> CreateOrUpdateAsync(RouteDto dto)
    {
        var result = await _commandRouteRepository.AddOrUpdateAsync(_mapper.Map<My.City.Core.Models.Route>(dto));
        dto.Id = result.Id;
        await _routePointService.CreateOrUpdateAsync(dto.Id, dto.RoutePointDto);
        return dto;
    }

    public void Delete(long id)
    {
        _commandRouteRepository.Delete(id);
    }

    public async Task<RouteDto> GetAsync(long id)
    {
        var result = await _commandRouteRepository.FindAsync(
            new ExpressionSpecification<My.City.Core.Models.Route>(x => x.Id == id));
        var route = _mapper.Map<RouteDto>(result);
        route.RoutePointDto = await _routePointService.GetAsync(id);
        return route;
    }
}