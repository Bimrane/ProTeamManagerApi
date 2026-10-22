using BlueWallApi.Core.Models;
using BlueWallApi.Core.Repositories;

namespace BlueWallApi.Core.Services;

public class TeamService : ITeamService
{
    private readonly ITeamRepository _teamRepository;

    public TeamService(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task<IEnumerable<Team>> GetAllTeamsAsync()
    {
        return await _teamRepository.GetAllAsync();
    }

    public async Task<Team?> GetTeamDetailsAsync(int id)
    {
        return await _teamRepository.GetByIdAsync(id);
    }

    public async Task<Team> CreateTeamAsync(string name, string game)
    {
        var team = new Team
        {
            Name = name,
            Game = game
        };

        return await _teamRepository.AddAsync(team);
    }
}