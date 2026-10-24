namespace ProTeamManagerApi.Core.DTOs;

public record PlayerResponseDto(int Id, string Nickname, string Role, int TeamId, string TeamName);