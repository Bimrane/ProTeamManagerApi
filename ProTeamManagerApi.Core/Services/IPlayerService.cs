using ProTeamManagerApi.Core.Models;

namespace ProTeamManagerApi.Core.Services;

public interface IPlayerService
{
    Task<IEnumerable<Player>> GetAllPlayersAsync();
    Task<Player?> GetPlayerByIdAsync(int id);
    Task<Player> CreatePlayerAsync(string nickname, string role, int teamId);
}