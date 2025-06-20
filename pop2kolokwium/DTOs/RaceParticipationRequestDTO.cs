namespace pop2kolokwium.DTOs;

public class RaceParticipationRequestDTO
{
    public int TrackRaceId { get; set; }
    public int FinishTimeInSeconds { get; set; }
    public int Position { get; set; }
}