namespace BlueWallApi.Core.Models;

public class Match
{
    public int Id { get; set; }
    public string Opponent { get; set; } = string.Empty; // Équipe adverse (ex: "Fnatic", "G2")
    public string Tournament { get; set; } = string.Empty; // ex: "LEC Spring 2026"
    public DateTime MatchDate { get; set; }
    public bool IsWon { get; set; } // Victoire ou Défaite
    
    // Clé étrangère et navigation vers l'équipe
    public int TeamId { get; set; }
    public Team? Team { get; set; }
}