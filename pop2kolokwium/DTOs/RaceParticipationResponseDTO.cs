namespace pop2kolokwium.DTOs;

public class RaceParticipationResponseDTO
{
    public string RaceName { get; set; }
    public string TrackName { get; set; }
    public DateTime RaceDate { get; set; }
    public int Laps { get; set; }
    public int FinishTimeInSeconds { get; set; }
    public int Position { get; set; }
}