using Microsoft.EntityFrameworkCore;
using ProTeamManagerApi.Core.Data;
using ProTeamManagerApi.Core.Models;

namespace ProTeamManagerApi.Core.Repositories;

public class PlayerRepository : IPlayerRepository
{
    private readonly ProTeamManagerDbContext _context;

    public PlayerRepository(ProTeamManagerDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Player>> GetAllAsync()
    {
        return await _context.Players
            .Include(p => p.Team)
            .ToListAsync();
    }

    public async Task<Player?> GetByIdAsync(int id)
    {
        return await _context.Players
            .Include(p => p.Team)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Player> AddAsync(Player player)
    {
        await _context.Players.AddAsync(player);
        await _context.SaveChangesAsync();
        return player;
    }

    public async Task UpdateAsync(Player player)
    {
        _context.Players.Update(player);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Player player)
    {
        _context.Players.Remove(player);
        await _context.SaveChangesAsync();
    }
}