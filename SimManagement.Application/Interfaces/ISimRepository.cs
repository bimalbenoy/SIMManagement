using SimManagement.Core.Entities;

namespace SimManagement.Application.Interfaces;

public interface ISimRepository
{
    Task<Sim?> GetByIdAsync(int id);

    Task<IReadOnlyList<Sim>> GetAllAsync();

    Task<Sim> AddAsync(Sim sim);

    Task UpdateAsync(Sim sim);

    Task DeleteAsync(Sim sim);
}