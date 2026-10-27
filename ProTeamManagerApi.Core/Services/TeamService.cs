using ProTeamManagerApi.Core.Models;
using ProTeamManagerApi.Core.Repositories;
using ProTeamManagerApi.Core.DTOs;

namespace ProTeamManagerApi.Core.Services;

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

    public async Task<bool> UpdateTeamAsync(int id, UpdateTeamDto updateDto)
    {
        var team = await _teamRepository.GetByIdAsync(id);
        if (team == null) return false;

        team.Name = updateDto.Name;
        team.Game = updateDto.Game;

        await _teamRepository.UpdateAsync(team);
        return true;
    }

    public async Task<bool> DeleteTeamAsync(int id)
    {
        var team = await _teamRepository.GetByIdAsync(id);
        if (team == null) return false;

        await _teamRepository.DeleteAsync(team);
        return true;
    }
}
