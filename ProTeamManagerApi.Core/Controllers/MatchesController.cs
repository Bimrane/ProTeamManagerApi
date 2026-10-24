using Microsoft.AspNetCore.Mvc;
using ProTeamManagerApi.Core.DTOs;
using ProTeamManagerApi.Core.Services;

namespace ProTeamManagerApi.Core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MatchesController : ControllerBase
{
    private readonly IMatchService _matchService;

    public MatchesController(IMatchService matchService)
    {
        _matchService = matchService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MatchResponseDto>>> GetAllMatches()
    {
        var matches = await _matchService.GetAllMatchesAsync();
        var response = matches.Select(m => new MatchResponseDto(
            m.Id,
            m.Opponent,
            m.Tournament,
            m.MatchDate,
            m.TeamScore,
            m.OpponentScore,
            m.IsWon,
            m.TeamId,
            m.Team?.Name ?? string.Empty
        ));

        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<MatchResponseDto>> GetMatchById(int id)
    {
        var match = await _matchService.GetMatchByIdAsync(id);
        if (match == null)
        {
            return NotFound(new ProblemDetails
            {
                Title = "Ressource introuvable",
                Detail = $"Le match avec l'ID {id} est introuvable.",
                Status = StatusCodes.Status404NotFound
            });
        }

        var response = new MatchResponseDto(
            match.Id,
            match.Opponent,
            match.Tournament,
            match.MatchDate,
            match.TeamScore,
            match.OpponentScore,
            match.IsWon,
            match.TeamId,
            match.Team?.Name ?? string.Empty
        );

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<MatchResponseDto>> CreateMatch([FromBody] CreateMatchDto createMatchDto)
    {
        try
        {
            var createdMatch = await _matchService.CreateMatchAsync(
                createMatchDto.Opponent,
                createMatchDto.Tournament,
                createMatchDto.MatchDate,
                createMatchDto.TeamScore,
                createMatchDto.OpponentScore,
                createMatchDto.TeamId
            );

            var response = new MatchResponseDto(
                createdMatch.Id,
                createdMatch.Opponent,
                createdMatch.Tournament,
                createdMatch.MatchDate,
                createdMatch.TeamScore,
                createdMatch.OpponentScore,
                createdMatch.IsWon,
                createdMatch.TeamId,
                createdMatch.Team?.Name ?? string.Empty
            );

            return CreatedAtAction(nameof(GetMatchById), new { id = createdMatch.Id }, response);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new ProblemDetails
            {
                Title = "Équipe introuvable",
                Detail = ex.Message,
                Status = StatusCodes.Status404NotFound
            });
        }
    }
}