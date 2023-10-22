using Business.Converters;
using Business.Model.Location;
using Dal.Repositories;

namespace Business.Service.Location;

public class LocationService : ILocationService
{
    private readonly ILocationRepository _locationRepository;
    private readonly ILocationConverters _locationConverters;
    private readonly IPointRepository _pointRepository;

    public LocationService(ILocationRepository locationRepository, ILocationConverters locationConverters, IPointRepository pointRepository)
    {
        _locationRepository = locationRepository;
        _locationConverters = locationConverters;
        _pointRepository = pointRepository;
    }

    public async Task<IReadOnlyCollection<LocationListDto>> ListAsync()
    {
        var result = await _locationRepository.GetAllAsync();
        return result.Select(x => new LocationListDto
        {
            Description = x.Description,
            Name = x.Name,
            Id = x.Id,
            PointId = x.Point.Id
        }).ToArray();
    }

    public async Task<LocationDto> CreateOrUpdateAsync(LocationDto locationDto)
    {
        var result = await _locationRepository.AddOrUpdateAsync(_locationConverters.Convert(locationDto));
        locationDto.Id = result.Id;
        return locationDto;
    }

    public void Delete(long id)
    {
        _locationRepository.Delete(id);
    }

    public async Task<LocationDto> GetAsync(long id)
    {
        var location = await _locationRepository.GetByIdAsync(id);
        location.Point = await _pointRepository.GetByIdAsync(location.Point.Id.Value);
        return _locationConverters.Convert(location);
    }
}