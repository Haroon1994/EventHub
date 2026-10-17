namespace EventHub.Domain.Entities;

public class Attendee
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;

    public Guid EventId { get; private set; }
    public Event Event { get; private set; } = null!;

    private Attendee() { }

    public static Attendee Create(string name, string email, Guid eventId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required.", nameof(name));

        return new Attendee
        {
            Id = Guid.NewGuid(),
            Name = name,
            Email = email,
            EventId = eventId
        };
    }
}