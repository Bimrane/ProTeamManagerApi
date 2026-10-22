using Microsoft.EntityFrameworkCore;
using BlueWallApi.Core.Data;
using BlueWallApi.Core.Models;

namespace BlueWallApi.Core.Repositories;

public class TeamRepository : ITeamRepository
{
    private readonly BlueWallDbContext _context;

    public TeamRepository(BlueWallDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Team>> GetAllAsync()
    {
        // Utilisation de LINQ et async/await pour récupérer les équipes avec leurs joueurs associés
        return await _context.Teams
            .Include(t => t.Players)
            .Include(t => t.Matches)
            .ToListAsync();
    }

    public async Task<Team?> GetByIdAsync(int id)
    {
        return await _context.Teams
            .Include(t => t.Players)
            .Include(t => t.Matches)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Team> AddAsync(Team team)
    {
        await _context.Teams.AddAsync(team);
        await _context.SaveChangesAsync();
        return team;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}