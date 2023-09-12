using MyCity.Core.Models;
using MyCity.DataAccess.Entities;

namespace MyCity.Core.Services
{
    public interface IEventService : IBaseService<Event, EventDto>
    {
        /*new Task<IEnumerable<EventDto>> ListAsync();
        new Task<EventDto> CreateAsync(EventDto dto);
        new Task<EventDto> UpdateAsync(EventDto dto);
        new Task DeleteAsync(long id);
        new Task<EventDto> GetAsync(long id);*/
    }
}
