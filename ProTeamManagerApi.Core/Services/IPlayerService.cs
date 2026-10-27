using ProTeamManagerApi.Core.Models;
using ProTeamManagerApi.Core.DTOs;

namespace ProTeamManagerApi.Core.Services;

public interface IPlayerService
{
    Task<IEnumerable<Player>> GetAllPlayersAsync();
    Task<Player?> GetPlayerByIdAsync(int id);
    Task<Player> CreatePlayerAsync(string nickname, string role, int teamId);
    Task<bool> UpdatePlayerAsync(int id, UpdatePlayerDto updateDto);
    Task<bool> DeletePlayerAsync(int id);
}