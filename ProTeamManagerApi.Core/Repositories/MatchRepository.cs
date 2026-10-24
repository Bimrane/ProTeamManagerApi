using Microsoft.EntityFrameworkCore;
using ProTeamManagerApi.Core.Data;
using ProTeamManagerApi.Core.Models;

namespace ProTeamManagerApi.Core.Repositories;

public class MatchRepository : IMatchRepository
{
    private readonly ProTeamManagerDbContext _context;

    public MatchRepository(ProTeamManagerDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Match>> GetAllAsync()
    {
        return await _context.Matches
            .Include(m => m.Team)
            .ToListAsync();
    }

    public async Task<Match?> GetByIdAsync(int id)
    {
        return await _context.Matches
            .Include(m => m.Team)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Match> AddAsync(Match match)
    {
        await _context.Matches.AddAsync(match);
        await _context.SaveChangesAsync();
        return match;
    }
}