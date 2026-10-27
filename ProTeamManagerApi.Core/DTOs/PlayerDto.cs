namespace ProTeamManagerApi.Core.DTOs;

public record CreatePlayerDto(string Nickname, string Role, int TeamId);
public record PlayerResponseDto(int Id, string Nickname, string Role, int TeamId, string TeamName);
public record UpdatePlayerDto(string Nickname, string Role, int TeamId);