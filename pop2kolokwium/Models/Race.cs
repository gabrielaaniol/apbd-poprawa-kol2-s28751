using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pop2kolokwium.Models;

[Table("Race")]
public class Race
{
    [Key]
    public int RaceId { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;
    
    [Required]
    [MaxLength(100)]
    public string Location { get; set; } = null!;
    public DateTime Date { get; set; }
    
    public ICollection<TrackRace> TrackRaces { get; set; }
}