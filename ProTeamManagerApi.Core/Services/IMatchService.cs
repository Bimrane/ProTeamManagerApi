using ProTeamManagerApi.Core.Models;
using ProTeamManagerApi.Core.DTOs;
namespace ProTeamManagerApi.Core.Services;

public interface IMatchService
{
    Task<IEnumerable<Match>> GetAllMatchesAsync();
    Task<Match?> GetMatchByIdAsync(int id);
    Task<Match> CreateMatchAsync(string opponent, string tournament, DateTime matchDate, int teamScore, int opponentScore, int teamId);
    Task<bool> UpdateMatchAsync(int id, UpdateMatchDto updateDto);
    Task<bool> DeleteMatchAsync(int id);
}