namespace ProTeamManagerApi.Core.DTOs;

public record CreateMatchDto(
    string Opponent, 
    string Tournament, 
    DateTime MatchDate, 
    int TeamScore, 
    int OpponentScore, 
    int TeamId
);