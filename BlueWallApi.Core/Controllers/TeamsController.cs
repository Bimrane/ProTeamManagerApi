using Microsoft.AspNetCore.Mvc;
using BlueWallApi.Core.DTOs;
using BlueWallApi.Core.Services;

namespace BlueWallApi.Core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamsController : ControllerBase
{
    private readonly ITeamService _teamService;

    public TeamsController(ITeamService teamService)
    {
        _teamService = teamService;
    }

    // GET: api/teams
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TeamResponseDto>>> GetAllTeams()
    {
        var teams = await _teamService.GetAllTeamsAsync();
        
        // Mapping manuel ou via AutoMapper (ici manuel pour la simplicité pédagogique)
        var response = teams.Select(t => new TeamResponseDto(
            t.Id,
            t.Name,
            t.Game,
            t.Players.Count
        ));

        return Ok(response); // HTTP 200 OK
    }

    // GET: api/teams/{id}
    [HttpGet("{id:int}")]
    public async Task<ActionResult<TeamResponseDto>> GetTeamById(int id)
    {
        var team = await _teamService.GetTeamDetailsAsync(id);

        if (team == null)
        {
            return NotFound(new { message = $"L'équipe avec l'ID {id} est introuvable." }); // HTTP 404 Not Found
        }

        var response = new TeamResponseDto(team.Id, team.Name, team.Game, team.Players.Count);
        return Ok(response); // HTTP 200 OK
    }

    // POST: api/teams
    [HttpPost]
    public async Task<ActionResult<TeamResponseDto>> CreateTeam([FromBody] CreateTeamDto createTeamDto)
    {
        // Grâce à [ApiController] et FluentValidation, si le DTO est invalide, 
        // ASP.NET Core retourne automatiquement un HTTP 400 Bad Request.

        var createdTeam = await _teamService.CreateTeamAsync(createTeamDto.Name, createTeamDto.Game);

        var response = new TeamResponseDto(createdTeam.Id, createdTeam.Name, createdTeam.Game, 0);

        // HTTP 201 Created avec l'en-tête Location pointant vers la ressource créée
        return CreatedAtAction(nameof(GetTeamById), new { id = createdTeam.Id }, response);
    }
}