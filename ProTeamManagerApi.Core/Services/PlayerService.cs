using ProTeamManagerApi.Core.Models;
using ProTeamManagerApi.Core.Repositories;
using ProTeamManagerApi.Core.DTOs;

namespace ProTeamManagerApi.Core.Services;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _playerRepository;
    private readonly ITeamRepository _teamRepository;

    public PlayerService(IPlayerRepository playerRepository, ITeamRepository teamRepository)
    {
        _playerRepository = playerRepository;
        _teamRepository = teamRepository;
    }

    public async Task<IEnumerable<Player>> GetAllPlayersAsync()
    {
        return await _playerRepository.GetAllAsync();
    }

    public async Task<Player?> GetPlayerByIdAsync(int id)
    {
        return await _playerRepository.GetByIdAsync(id);
    }

    public async Task<Player> CreatePlayerAsync(string nickname, string role, int teamId)
    {
        var team = await _teamRepository.GetByIdAsync(teamId);
        if (team == null)
        {
            throw new KeyNotFoundException($"L'équipe avec l'ID {teamId} est introuvable.");
        }

        var player = new Player
        {
            Nickname = nickname,
            Role = role,
            TeamId = teamId
        };

        return await _playerRepository.AddAsync(player);
    }

    public async Task<bool> UpdatePlayerAsync(int id, UpdatePlayerDto updateDto)
    {
        var player = await _playerRepository.GetByIdAsync(id);
        if (player == null) return false;

        var teamExists = await _teamRepository.ExistsAsync(updateDto.TeamId);
        if (!teamExists) return false;

        player.Nickname = updateDto.Nickname;
        player.Role = updateDto.Role;
        player.TeamId = updateDto.TeamId;

        await _playerRepository.UpdateAsync(player);
        return true;
    }

    public async Task<bool> DeletePlayerAsync(int id)
    {
        var player = await _playerRepository.GetByIdAsync(id);
        if (player == null) return false;

        await _playerRepository.DeleteAsync(player);
        return true;
    }
}