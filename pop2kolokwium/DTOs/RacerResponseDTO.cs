namespace pop2kolokwium.DTOs;

public class RacerResponseDTO
{
    public int RacerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public List<RaceParticipationResponseDTO> Participations { get; set; }
}