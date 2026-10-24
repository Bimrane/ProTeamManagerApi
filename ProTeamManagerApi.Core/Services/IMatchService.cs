using ProTeamManagerApi.Core.Models;

namespace ProTeamManagerApi.Core.Services;

public interface IMatchService
{
    Task<IEnumerable<Match>> GetAllMatchesAsync();
    Task<Match?> GetMatchByIdAsync(int id);
    Task<Match> CreateMatchAsync(string opponent, string tournament, DateTime matchDate, int teamScore, int opponentScore, int teamId);
}