using EventHub.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventHub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly EventService _eventService;

    public EventsController(EventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var events = await _eventService.GetAllEventsAsync();
        return Ok(events);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var @event = await _eventService.GetEventByIdAsync(id);
        if (@event == null)
        {
            return NotFound();
        }
        return Ok(@event);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEventRequest request)
    {
        var @event = await _eventService.CreateEventAsync(
            request.Title,
            request.Description,
            request.StartDate,
            request.EndDate,
            request.Location,
            request.OrganizerId);

        return CreatedAtAction(nameof(GetById), new { id = @event.Id }, @event);
    }
}

public record CreateEventRequest(
    string Title,
    string Description,
    DateTime StartDate,
    DateTime EndDate,
    string Location,
    Guid OrganizerId);