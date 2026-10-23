namespace ProTeamManagerApi.Core.Models;

public class Match
{
    public int Id { get; set; }
    public string Opponent { get; set; } = string.Empty;
    public string Tournament { get; set; } = string.Empty;
    public DateTime MatchDate { get; set; }
    public bool IsWon { get; set; }

    // Clé étrangère et navigation vers l'équipe
    public int TeamId { get; set; }
    public Team? Team { get; set; }
}
