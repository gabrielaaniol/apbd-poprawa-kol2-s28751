using Microsoft.EntityFrameworkCore;
using pop2kolokwium.Models;

namespace pop2kolokwium.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext (DbContextOptions<DatabaseContext> options) : base(options) { }
    
    public DbSet<Racer> Racers { get; set; }
    public DbSet<Race> Races { get; set; }
    public DbSet<Track> Tracks { get; set; }
    public DbSet<TrackRace> TrackRaces { get; set; }
    public DbSet<RaceParticipation> RaceParticipations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RaceParticipation>()
            .HasKey(p => new { p.RacerId, p.TrackRaceId });

        modelBuilder.Entity<Racer>().HasData(new Racer
        {
            RacerId = 1,
            FirstName = "Lewis",
            LastName = "Hamilton"
        });

        modelBuilder.Entity<Models.Race>().HasData(new Models.Race
        {
            RaceId = 1,
            Name = "British Grand Prix",
            Location = "Silverstone, UK",
            Date = new DateTime(2025, 07, 14)
        });
        
        modelBuilder.Entity<Track>().HasData(new Track
        {
            TrackId = 1,
            Name = "Silverstone Circuit",
            LengthInKm = 5.89
        });

        modelBuilder.Entity<TrackRace>().HasData(new TrackRace
        {
            TrackRaceId = 1,
            TrackId = 1,
            RaceId = 1,
            Laps = 52,
            BestTimeInSeconds = 5480
        });

        modelBuilder.Entity<RaceParticipation>().HasData(new RaceParticipation
        {
            RacerId = 1,
            TrackRaceId = 1,
            FinishTimeInSeconds = 5460,
            Position = 1
        });
    }
}