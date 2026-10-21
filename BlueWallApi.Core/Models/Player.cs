namespace BlueWallApi.Core.Models;

public class Player
{
    public int Id { get; set; }
    public string Pseudo { get; set; } = string.Empty; // ex: "Canna", "Vladi"
    public string Role { get; set; } = string.Empty; // ex: "Toplaner", "Midlaner"
    
    // Clé étrangère et navigation vers l'équipe
    public int TeamId { get; set; }
    public Team? Team { get; set; }
}