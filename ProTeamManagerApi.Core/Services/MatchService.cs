using ProTeamManagerApi.Core.Models;
using ProTeamManagerApi.Core.Repositories;
using ProTeamManagerApi.Core.DTOs;

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

    public async Task<bool> UpdateMatchAsync(int id, UpdateMatchDto updateDto)
    {
        var match = await _matchRepository.GetByIdAsync(id);
        if (match == null) return false;

        var teamExists = await _teamRepository.ExistsAsync(updateDto.TeamId);
        if (!teamExists) return false;

        match.Opponent = updateDto.Opponent;
        match.Tournament = updateDto.Tournament;
        match.MatchDate = updateDto.MatchDate;
        match.TeamScore = updateDto.TeamScore;
        match.OpponentScore = updateDto.OpponentScore;
        match.TeamId = updateDto.TeamId;

        await _matchRepository.UpdateAsync(match);
        return true;
    }

    public async Task<bool> DeleteMatchAsync(int id)
    {
        var match = await _matchRepository.GetByIdAsync(id);
        if (match == null) return false;

        await _matchRepository.DeleteAsync(match);
        return true;
    }
}