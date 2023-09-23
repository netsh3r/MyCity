namespace MyCity.DataAccess.Repository
{
    using Microsoft.EntityFrameworkCore;
    using MyCity.Core.Repository;
    using MyCity.DataAccess.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EventRepository : IRepository<Event>
    {
        private readonly ApplicationContext _db;

        public EventRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<Event> CreateAsync(Event entity)
        {
            await _db.Events.AddAsync(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await GetAsync(id);
            _db.Events.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public DbSet<Event> GetAll()
        {
            return _db.Events;
        }

        public async Task<Event?> GetAsync(long id)
        {
            return await _db.Events.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Event>> ListAsync()
        {
            return await _db.Events.ToListAsync();
        }

        public async Task<Event> UpdateAsync(Event entity)
        {
            _db.Events.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
