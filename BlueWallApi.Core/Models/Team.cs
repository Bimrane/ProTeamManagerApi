namespace BlueWallApi.Core.Models;

public class Team
{
    public int Id { get; set; } // Clé primaire auto-incrémentée
    public string Name { get; set; } = string.Empty; // ex: "Karmine Corp"
    public string Game { get; set; } = string.Empty; // ex: "League of Legends", "Valorant"
    
    // Relations : Une équipe possède plusieurs joueurs et plusieurs matchs
    public ICollection<Player> Players { get; set; } = new List<Player>();
    public ICollection<Match> Matches { get; set; } = new List<Match>();
}