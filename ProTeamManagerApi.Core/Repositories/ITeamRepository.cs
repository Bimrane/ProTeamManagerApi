using ProTeamManagerApi.Core.Models;

namespace ProTeamManagerApi.Core.Repositories;

public interface ITeamRepository
{
    Task<IEnumerable<Team>> GetAllAsync();
    Task<Team?> GetByIdAsync(int id);
    Task<Team> AddAsync(Team team);
    Task SaveChangesAsync();
}