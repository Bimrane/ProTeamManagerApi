namespace ProTeamManagerApi.Core.Models;

public class Match
{
    public int Id { get; set; }
    public string Opponent { get; set; } = string.Empty;
    public string Tournament { get; set; } = string.Empty;
    public DateTime MatchDate { get; set; }
    
    public int TeamScore { get; set; }
    public int OpponentScore { get; set; }
    
    public bool IsWon => TeamScore > OpponentScore;

    public int TeamId { get; set; }
    public Team? Team { get; set; }
}