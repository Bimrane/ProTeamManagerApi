namespace ProTeamManagerApi.Core.DTOs;

public record CreateTeamDto(string Name, string Game);
public record TeamResponseDto(int Id, string Name, string Game, int PlayerCount);
public record UpdateTeamDto(string Name, string Game);