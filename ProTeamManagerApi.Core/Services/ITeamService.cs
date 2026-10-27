using ProTeamManagerApi.Core.Models;
using ProTeamManagerApi.Core.DTOs;
namespace ProTeamManagerApi.Core.Services;

public interface ITeamService
{
    Task<IEnumerable<Team>> GetAllTeamsAsync();
    Task<Team?> GetTeamDetailsAsync(int id);
    Task<Team> CreateTeamAsync(string name, string game);
    Task<bool> UpdateTeamAsync(int id, UpdateTeamDto updateDto);
    Task<bool> DeleteTeamAsync(int id);
}
