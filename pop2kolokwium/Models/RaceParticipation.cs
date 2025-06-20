using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pop2kolokwium.Models;

[PrimaryKey(nameof(TrackRaceId), nameof(RacerId))]
[Table("Race_Participation")]
public class RaceParticipation
{
    [ForeignKey("TrackRace")]
    public int TrackRaceId { get; set; }
    public TrackRace TrackRace { get; set; } = null!;
    
    [ForeignKey("Racer")]
    public int RacerId { get; set; }
    public Racer Racer { get; set; } = null!;
    
    public int FinishTimeInSeconds { get; set; }
    public int Position { get; set; }
}