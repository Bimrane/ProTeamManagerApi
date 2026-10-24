using ProTeamManagerApi.Core.Models;
using ProTeamManagerApi.Core.Repositories;

namespace ProTeamManagerApi.Core.Services;

public class MatchService : IMatchService
{
    private readonly IMatchRepository _matchRepository;
    private readonly ITeamRepository _teamRepository;

    public MatchService(IMatchRepository matchRepository, ITeamRepository teamRepository)
    {
        _matchRepository = matchRepository;
        _teamRepository = teamRepository;
    }

    public async Task<IEnumerable<Match>> GetAllMatchesAsync()
    {
        return await _matchRepository.GetAllAsync();
    }

    public async Task<Match?> GetMatchByIdAsync(int id)
    {
        return await _matchRepository.GetByIdAsync(id);
    }

    public async Task<Match> CreateMatchAsync(string opponent, string tournament, DateTime matchDate, int teamScore, int opponentScore, int teamId)
    {
        var team = await _teamRepository.GetByIdAsync(teamId);
        if (team == null)
        {
            throw new KeyNotFoundException($"L'équipe avec l'ID {teamId} est introuvable.");
        }

        var match = new Match
        {
            Opponent = opponent,
            Tournament = tournament,
            MatchDate = matchDate,
            TeamScore = teamScore,
            OpponentScore = opponentScore,
            TeamId = teamId
        };

        return await _matchRepository.AddAsync(match);
    }
}