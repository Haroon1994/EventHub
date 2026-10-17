namespace EventHub.Domain.Entities;

public class Organizer
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;

    public ICollection<Event> Events { get; private set; } = new List<Event>();

    private Organizer() { }

    public static Organizer Create(string name, string email)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required.", nameof(name));
        if (!email.Contains('@'))
            throw new ArgumentException("Invalid email address.", nameof(email));

        return new Organizer
        {
            Id = Guid.NewGuid(),
            Name = name,
            Email = email
        };
    }
}