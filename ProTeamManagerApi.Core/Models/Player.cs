namespace ProTeamManagerApi.Core.Models;

public class Player
{
    public int Id { get; set; }
    public string Nickname { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;

    public int TeamId { get; set; }
    public Team? Team { get; set; }
}
