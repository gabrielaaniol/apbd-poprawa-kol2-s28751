using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pop2kolokwium.Data;
using pop2kolokwium.DTOs;
using pop2kolokwium.Models;

namespace pop2kolokwium.Service;

public class DbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    // GET 
    [HttpGet("{id}/participations")]
    public async Task<RacerResponseDTO> GetRacerParticipationsAsync(int racerId)
    {
        var racer = await _context.Racers
            .Where(r => r.RacerId == racerId)
            .Select(r => new RacerResponseDTO
            {
                RacerId = r.RacerId,
                FirstName = r.FirstName,
                LastName = r.LastName,
                Participations = r.RaceParticipations.Select(p => new RaceParticipationResponseDTO //r.RP
                {
                    RaceName = p.TrackRace.Race.Name,
                    TrackName = p.TrackRace.Track.Name,
                    Laps = p.TrackRace.Laps,
                    FinishTimeInSeconds = p.FinishTimeInSeconds,
                    Position = p.Position
                }).ToList()
            })
            .FirstOrDefaultAsync();

        if (racer is null)
            throw new Exception($"zawodnik o ID {racerId} nie istnieje.");

        return racer;
    }

    
    //POST
    public async Task AddRacerToRaceAsync(RacerRequestDTO dto)
    {
        var racer = new Racer
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName
        };

        _context.Racers.Add(racer);
        await _context.SaveChangesAsync(); 

        foreach (var p in dto.Participations)
        {
            var trackRace = await _context.TrackRaces.FirstOrDefaultAsync(tr => tr.TrackRaceId == p.TrackRaceId);
            if (trackRace == null)
                throw new Exception($"Nie znalezionno TrackRaceId = {p.TrackRaceId}");

            _context.RaceParticipations.Add(new RaceParticipation
            {
                RacerId = racer.RacerId,
                TrackRaceId = p.TrackRaceId,
                FinishTimeInSeconds = p.FinishTimeInSeconds,
                Position = p.Position
            });
        }
    }
}