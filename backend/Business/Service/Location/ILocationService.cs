using Business.Model.Location;

namespace Business.Service.Location;

public interface ILocationService
{
    Task<IReadOnlyCollection<LocationListDto>> ListAsync();
    Task<LocationDto> CreateOrUpdateAsync(LocationDto locationDto);
    void Delete(long id);
    Task<LocationDto> GetAsync(long id);
}