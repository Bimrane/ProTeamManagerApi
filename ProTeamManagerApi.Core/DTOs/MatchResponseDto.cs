namespace ProTeamManagerApi.Core.DTOs;

public record MatchResponseDto(
    int Id, 
    string Opponent, 
    string Tournament, 
    DateTime MatchDate, 
    int TeamScore, 
    int OpponentScore, 
    bool IsWon, 
    int TeamId, 
    string TeamName
);