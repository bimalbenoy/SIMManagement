
using SimManagement.Application.DTOs;
using SimManagement.Application.Interfaces;
using SimManagement.Application.Mappings;
using SimManagement.Core.Entities;

namespace SimManagement.Application.Services;

public class SimService : ISimService
{
    private readonly ISimRepository _simRepository;

    public SimService(ISimRepository simRepository)
    {
        _simRepository = simRepository;
    }

    public async Task<SimResponseDto?> GetByIdAsync(int id)
    {
        var sim = await _simRepository.GetByIdAsync(id);

        return sim is null ? null : SimMapping.ToResponseDto(sim);
    }

    public async Task<IReadOnlyList<SimResponseDto>> GetAllAsync()
    {
        var sims = await _simRepository.GetAllAsync();

        return sims.Select(SimMapping.ToResponseDto).ToList();
    }

    public async Task<SimResponseDto> CreateAsync(CreateSimDto dto)
    {
        var sim = SimMapping.ToEntity(dto);

        var createdSim = await _simRepository.AddAsync(sim);

        return SimMapping.ToResponseDto(createdSim);
    }

    public async Task<bool> UpdateAsync(int id, UpdateSimDto dto)
    {
        var sim = await _simRepository.GetByIdAsync(id);

        if (sim is null)
        {
            return false;
        }

        SimMapping.UpdateEntity(sim, dto);

        await _simRepository.UpdateAsync(sim);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var sim = await _simRepository.GetByIdAsync(id);

        if (sim is null)
        {
            return false;
        }

        await _simRepository.DeleteAsync(sim);

        return true;
    }
}
