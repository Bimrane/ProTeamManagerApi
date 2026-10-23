namespace ProTeamManagerApi.Core.Models;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Game { get; set; } = string.Empty;

    // Relations : Une équipe possède plusieurs joueurs et plusieurs matchs
    public ICollection<Player> Players { get; set; } = new List<Player>();
    public ICollection<Match> Matches { get; set; } = new List<Match>();
}
