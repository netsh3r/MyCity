namespace MyCity.Event.Service.Services
{
    using MyCity.Core.Models;
    using MyCity.Core.Services;
    using DataAccess.Entities;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class EventService : IEventService
    {
        public Task<Event> CreateAsync(EventDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Event> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Event>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Event> UpdateAsync(EventDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
