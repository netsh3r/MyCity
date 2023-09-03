using AutoMapper;

namespace MyCity.Location.Services;

using MyCity.Core.Models;
using MyCity.Core.Services;
using MyCity.Core.Repository;
using MyCity.DataAccess.Entities;

public class LocationService : ILocationService
{
    private readonly IRepository<Location> _repositoryLocation;
    private readonly IMapper _mapper;
    
    public LocationService(IRepository<Location> repositoryLocation, IMapper mapper)
    {
        _repositoryLocation = repositoryLocation;
        _mapper = mapper;
    }
    
    public Task<IEnumerable<Location>> ListAsync()
    {
        return _repositoryLocation.ListAsync();
    }

    public async Task<Location> CrateAsync(LocationDto locationDto)
    {
        var location = _mapper.Map<Location>(locationDto);
        return await _repositoryLocation.CreateAsync(location);
    }

    public Task<Location> UpdateAsync(LocationDto locationDto)
    {
        var location = _mapper.Map<Location>(locationDto);
        return _repositoryLocation.UpdateAsync(location);
    }

    public async Task DeleteAsync(long id)
    {
        await _repositoryLocation.DeleteAsync(id);
    }

    public async Task<Location> GetAsync(long id)
    {
        var location = await _repositoryLocation.GetAsync(id);
        return location;
    }
}