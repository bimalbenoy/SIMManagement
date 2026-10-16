using Microsoft.EntityFrameworkCore;
using SimManagement.Application.Interfaces;
using SimManagement.Core.Entities;
using SimManagement.Infrastructure.Persistence.DbContext;

namespace SimManagement.Infrastructure.Persistence.Repositories;

public class SimRepository : ISimRepository
{
    private readonly SimManagementDbContext _context;

    public SimRepository(SimManagementDbContext context)
    {
        _context = context;
    }

    public async Task<Sim?> GetByIdAsync(int id)
    {
        return await _context.Sims
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<IReadOnlyList<Sim>> GetAllAsync()
    {
        return await _context.Sims
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Sim> AddAsync(Sim sim)
    {
        await _context.Sims.AddAsync(sim);
        await _context.SaveChangesAsync();

        return sim;
    }

    public async Task UpdateAsync(Sim sim)
    {
        _context.Sims.Update(sim);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Sim sim)
    {
        _context.Sims.Remove(sim);
        await _context.SaveChangesAsync();
    }
}