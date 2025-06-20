namespace pop2kolokwium.Models;

public class Racer
{
    public int RacerId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    
    public ICollection<RaceParticipation> RaceParticipations { get; set; } 
}