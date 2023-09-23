namespace MyCity.Event.Service.Services
{
    using MyCity.Core.Models;
    using MyCity.Core.Services;
    using DataAccess.Entities;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using MyCity.Core.Repository;

    public class EventService : IEventService
    {
        private readonly IRepository<Event> _eventRepository;

        public EventService(IRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<Event> CreateAsync(EventDto dto)
        {
            try
            {
                var entity = new Event
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    DateStart = dto.DateStart,
                    DateEnd = dto.DateEnd,
                    LocationId = dto.LocationId,
                    Images = dto.Images
                };
                return await _eventRepository.CreateAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message);
            }            
        }

        public async Task DeleteAsync(long id)
        {
            try
            {
                await _eventRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message);
            }
        }

        public async Task<Event> GetAsync(long id)
        {
            try
            {
                var entity = await _eventRepository.GetAsync(id);
                if (entity == null)
                    throw new Exception(message: "Не найдено");

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message);
            } 
        }

        public async Task<IEnumerable<Event>> ListAsync()
        {
            try
            {
                return await _eventRepository.ListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message);
            }
        }

        public async Task<Event> UpdateAsync(EventDto dto)
        {
            try
            {
                var entity = new Event
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    DateStart = dto.DateStart,
                    DateEnd = dto.DateEnd,
                    LocationId = dto.LocationId,
                    Images = dto.Images
                };

                return await _eventRepository.UpdateAsync(entity);
            } 
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message);
            }
        }
    }
}
