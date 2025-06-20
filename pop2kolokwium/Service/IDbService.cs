using pop2kolokwium.DTOs;

namespace pop2kolokwium.Service;

public interface IDbService
{
    Task<RacerResponseDTO> GetRacerParticipationsAsync(int racerId);
    Task AddRacerToRaceAsync(RacerRequestDTO dto);
}