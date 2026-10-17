using EventHub.Application.Interfaces;
using EventHub.Domain.Entities;
using EventHub.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EventHub.Infrastructure.Repositories;

public class EventRepository : IEventRepository
{
    private readonly AppDbContext _db;

    public EventRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Event?> GetByIdAsync(Guid id)
    {
        return await _db.Events
            .Include(e => e.Organizer)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<Event>> GetAllAsync()
    {
        return await _db.Events
            .Include(e => e.Organizer)
            .ToListAsync();
    }

    public async Task AddAsync(Event @event)
    {
        await _db.Events.AddAsync(@event);
    }

    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }
}
