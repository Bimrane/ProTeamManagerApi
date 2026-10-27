using Microsoft.EntityFrameworkCore;
using ProTeamManagerApi.Core.Data;
using ProTeamManagerApi.Core.Models;

namespace ProTeamManagerApi.Core.Repositories;

public class TeamRepository : ITeamRepository
{
    private readonly ProTeamManagerDbContext _context;

    public TeamRepository(ProTeamManagerDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Team>> GetAllAsync()
    {
        return await _context.Teams
            .Include(t => t.Players)
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

    public async Task UpdateAsync(Team team)
    {
        _context.Teams.Update(team);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Team team)
    {
        _context.Teams.Remove(team);
        await _context.SaveChangesAsync();
    }
    
    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Teams.AnyAsync(t => t.Id == id);
    }
}
