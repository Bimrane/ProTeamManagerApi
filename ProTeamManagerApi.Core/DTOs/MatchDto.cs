namespace ProTeamManagerApi.Core.DTOs;

public record CreateMatchDto(
    string Opponent, 
    string Tournament, 
    DateTime MatchDate, 
    int TeamScore, 
    int OpponentScore, 
    int TeamId
);
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

public record UpdateMatchDto(
    string Opponent, 
    string Tournament, 
    DateTime MatchDate, 
    int TeamScore, 
    int OpponentScore, 
    int TeamId
);