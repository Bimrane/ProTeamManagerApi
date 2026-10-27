using ProTeamManagerApi.Core.Models;

namespace ProTeamManagerApi.Core.Repositories;

public interface IMatchRepository
{
    Task<IEnumerable<Match>> GetAllAsync();
    Task<Match?> GetByIdAsync(int id);
    Task<Match> AddAsync(Match match);
    Task UpdateAsync(Match match);
    Task DeleteAsync(Match match);
}