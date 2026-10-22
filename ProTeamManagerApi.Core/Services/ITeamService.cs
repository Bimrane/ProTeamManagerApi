using ProTeamManagerApi.Core.Models;

namespace ProTeamManagerApi.Core.Services;

public interface ITeamService
{
    Task<IEnumerable<Team>> GetAllTeamsAsync();
    Task<Team?> GetTeamDetailsAsync(int id);
    Task<Team> CreateTeamAsync(string name, string game);
}