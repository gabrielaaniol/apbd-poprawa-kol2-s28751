namespace pop2kolokwium.DTOs;

public class RacerRequestDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public List<RaceParticipationRequestDTO> Participations { get; set; }
}