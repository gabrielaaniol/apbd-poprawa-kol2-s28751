namespace pop2kolokwium.Models;

public class Track
{
    public int TrackId { get; set; }
    public string Name { get; set; } = null!;
    public double LengthInKm { get; set; }
    
    public ICollection<TrackRace> TrackRaces { get; set; }
}