using EventHub.Domain.Entities;

namespace EventHub.Application.Interfaces;

public interface IEventRepository
{
    Task<Event?> GetByIdAsync(Guid id);
    Task<IEnumerable<Event>> GetAllAsync();
    Task AddAsync(Event @event);
    Task SaveChangesAsync();
}
