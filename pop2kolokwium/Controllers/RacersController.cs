using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using pop2kolokwium.DTOs;
using pop2kolokwium.Service;

namespace pop2kolokwium.Controllers;


[ApiController]
[Route("api/[controller]")]
public class RacersController : Controller
{
    private readonly IDbService _dbService;

    public RacersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    // GET 
    [HttpGet("{id}/participations")]
    public async Task<IActionResult> GetRacerParticipations(int id)
    {
        try
        {
            var result = await _dbService.GetRacerParticipationsAsync(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    
    //POST
    [HttpPost("/api/track-races/participants")]
    public async Task<IActionResult> AddRacerParticipation([FromBody] RacerRequestDTO dto)
    {
        try
        {
            await _dbService.AddRacerToRaceAsync(dto);
            return Created(); 
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}