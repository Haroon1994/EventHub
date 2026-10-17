using EventHub.Application.Interfaces;
using EventHub.Domain.Entities;

namespace EventHub.Application.Services;

public class EventService
{
    private readonly IEventRepository _repository;

    public EventService(IEventRepository repository)
    {
        _repository = repository;
    }

    public async Task<Event> CreateEventAsync(string title, string description, DateTime start, DateTime end, string location, Guid organizerId)
    {
        var @event = Event.Create(title, description, start, end, location, organizerId);
        await _repository.AddAsync(@event);
        await _repository.SaveChangesAsync();
        return @event;
    }

    public async Task<IEnumerable<Event>> GetAllEventsAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Event?> GetEventByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }
}
