using AutoMapper;
using Business.Model.Location;
using My.City.Abstraction.Dal.Repository;
using My.City.Common.Specification;

namespace Business.Service.Location;

public class LocationService : ILocationService
{
    private readonly ICommandRepository<My.City.Core.Models.Location, long> _crudLocationRepository;
    private readonly IMapper _mapper;
    
    public LocationService(ICommandRepository<My.City.Core.Models.Location, long> crudLocationRepository, IMapper mapper)
    {
        _crudLocationRepository = crudLocationRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<LocationListDto>> ListAsync()
    {
        var result = await _crudLocationRepository.GetAllAsync();
        return result.Select(x => new LocationListDto
        {
            Description = x.Description,
            Name = x.Name,
            Id = x.Id
        }).ToArray();
    }

    public async Task<LocationDto> CreateOrUpdateAsync(LocationDto locationDto)
    {
        var location = _mapper.Map<My.City.Core.Models.Location>(locationDto);
        await _crudLocationRepository.AddAsync(location);
        locationDto.Id = location.Id;
        return locationDto;
    }

    public void Delete(long id)
    {
        _crudLocationRepository.Delete(id);
    }

    public async Task<LocationDto> GetAsync(long id)
    {
        var location = await _crudLocationRepository.FindAsync(
            new ExpressionSpecification<My.City.Core.Models.Location>(x => x.Id == id));
        return _mapper.Map<LocationDto>(location);
    }
}