using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pop2kolokwium.Models;

[Table("Track")]
public class Track
{
    [Key]
    public int TrackId { get; set; }
    public string Name { get; set; } = null!;
    public double LengthInKm { get; set; }
    
    public ICollection<TrackRace> TrackRaces { get; set; }
}