using ProTeamManagerApi.Core.Models;

namespace ProTeamManagerApi.Core.Repositories;

public interface ITeamRepository
{
    Task<IEnumerable<Team>> GetAllAsync();
    Task<Team?> GetByIdAsync(int id);
    Task<Team> AddAsync(Team team);
    Task SaveChangesAsync();
    Task UpdateAsync(Team team);
    Task DeleteAsync(Team team);
    Task<bool> ExistsAsync(int id);
}
