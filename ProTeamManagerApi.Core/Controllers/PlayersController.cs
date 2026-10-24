using Microsoft.AspNetCore.Mvc;
using ProTeamManagerApi.Core.DTOs;
using ProTeamManagerApi.Core.Services;

namespace ProTeamManagerApi.Core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly IPlayerService _playerService;

    public PlayersController(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlayerResponseDto>>> GetAllPlayers()
    {
        var players = await _playerService.GetAllPlayersAsync();
        var response = players.Select(p => new PlayerResponseDto(
            p.Id,
            p.Nickname,
            p.Role,
            p.TeamId,
            p.Team?.Name ?? string.Empty
        ));

        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PlayerResponseDto>> GetPlayerById(int id)
    {
        var player = await _playerService.GetPlayerByIdAsync(id);
        if (player == null)
        {
            return NotFound(new ProblemDetails
            {
                Title = "Ressource introuvable",
                Detail = $"Le joueur avec l'ID {id} est introuvable.",
                Status = StatusCodes.Status404NotFound
            });
        }

        var response = new PlayerResponseDto(
            player.Id,
            player.Nickname,
            player.Role,
            player.TeamId,
            player.Team?.Name ?? string.Empty
        );

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<PlayerResponseDto>> CreatePlayer([FromBody] CreatePlayerDto createPlayerDto)
    {
        try
        {
            var createdPlayer = await _playerService.CreatePlayerAsync(
                createPlayerDto.Nickname,
                createPlayerDto.Role,
                createPlayerDto.TeamId
            );

            var response = new PlayerResponseDto(
                createdPlayer.Id,
                createdPlayer.Nickname,
                createdPlayer.Role,
                createdPlayer.TeamId,
                createdPlayer.Team?.Name ?? string.Empty
            );

            return CreatedAtAction(nameof(GetPlayerById), new { id = createdPlayer.Id }, response);
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