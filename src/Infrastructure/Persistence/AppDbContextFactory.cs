using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EventHub.Infrastructure.Persistence;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        
        // Hardcoded connection string just for the migration tool.
        // The actual app uses appsettings.json in the API project.
        optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=eventhub;Username=postgres;Password=postgres");

        return new AppDbContext(optionsBuilder.Options);
    }
}
