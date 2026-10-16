
using Microsoft.EntityFrameworkCore;
using SimManagement.SyncWorker.Models;

namespace SimManagement.SyncWorker.Data.Repositories;

public class SimSyncRepository
{
    private readonly SimSyncDbContext _dbContext;

    public SimSyncRepository(SimSyncDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<SimReadModel?> GetByIdAsync(int id)
    {
        return await _dbContext.Sims
            .AsNoTracking()
            .FirstOrDefaultAsync(sim => sim.Id == id);
    }
}
