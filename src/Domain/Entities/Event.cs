namespace EventHub.Domain.Entities;

public class Event
{
    public Guid Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public string Location { get; private set; } = string.Empty;
    public Guid OrganizerId { get; private set; }

    public Organizer Organizer { get; private set; } = null!;
    public ICollection<Attendee> Attendees { get; private set; } = new List<Attendee>();

    private Event() { } // Required by Entity Framework Core

    public static Event Create(string title, string description, DateTime startDate, DateTime endDate, string location, Guid organizerId)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.", nameof(title));

        if (endDate <= startDate)
            throw new ArgumentException("End date must be after start date.");

        return new Event
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = description,
            StartDate = startDate,
            EndDate = endDate,
            Location = location,
            OrganizerId = organizerId
        };
    }
}