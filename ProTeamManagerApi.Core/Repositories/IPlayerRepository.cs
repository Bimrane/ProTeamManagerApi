using ProTeamManagerApi.Core.Models;

namespace ProTeamManagerApi.Core.Repositories;

public interface IPlayerRepository
{
    Task<IEnumerable<Player>> GetAllAsync();
    Task<Player?> GetByIdAsync(int id);
    Task<Player> AddAsync(Player player);
}