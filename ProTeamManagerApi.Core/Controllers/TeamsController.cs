using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ProTeamManagerApi.Core.DTOs;
using ProTeamManagerApi.Core.Services;

namespace ProTeamManagerApi.Core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamsController : ControllerBase
{
    private readonly ITeamService _teamService;

    private readonly IValidator<CreateTeamDto> _validator;

    public TeamsController(ITeamService teamService, IValidator<CreateTeamDto> validator)
    {
        _teamService = teamService;
        _validator = validator;
    }

    // GET: api/teams
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TeamResponseDto>>> GetAllTeams()
    {
        var teams = await _teamService.GetAllTeamsAsync();

        var response = teams.Select(t => new TeamResponseDto(
            t.Id,
            t.Name,
            t.Game,
            t.Players.Count
        ));

        return Ok(response);
    }

    // GET: api/teams/{id}
    [HttpGet("{id:int}")]
    public async Task<ActionResult<TeamResponseDto>> GetTeamById(int id)
    {
        var team = await _teamService.GetTeamDetailsAsync(id);

        if (team == null)
        {
            return NotFound(new ProblemDetails
            {
                Title = "Ressource introuvable",
                Detail = $"L'équipe avec l'ID {id} est introuvable.",
                Status = StatusCodes.Status404NotFound
            });
        }

        var response = new TeamResponseDto(team.Id, team.Name, team.Game, team.Players.Count);
        return Ok(response);
    }

    // POST: api/teams
    [HttpPost]
    public async Task<ActionResult<TeamResponseDto>> CreateTeam([FromBody] CreateTeamDto createTeamDto)
    {
        var validation = await _validator.ValidateAsync(createTeamDto);

        if (!validation.IsValid)
        {
            var errors = validation.Errors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(e => e.ErrorMessage).ToArray());

            return ValidationProblem(new ValidationProblemDetails(errors));
        }

        var createdTeam = await _teamService.CreateTeamAsync(
            createTeamDto.Name,
            createTeamDto.Game);

        var response = new TeamResponseDto(
            createdTeam.Id,
            createdTeam.Name,
            createdTeam.Game,
            0);

        return CreatedAtAction(
            nameof(GetTeamById),
            new { id = createdTeam.Id },
            response);
    }
}
