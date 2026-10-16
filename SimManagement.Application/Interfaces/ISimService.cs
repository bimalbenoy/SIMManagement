
using SimManagement.Application.DTOs;

namespace SimManagement.Application.Interfaces;

public interface ISimService
{
    Task<SimResponseDto?> GetByIdAsync(int id);

    Task<IReadOnlyList<SimResponseDto>> GetAllAsync();

    Task<SimResponseDto> CreateAsync(CreateSimDto dto);

    Task<bool> UpdateAsync(int id, UpdateSimDto dto);

    Task<bool> DeleteAsync(int id);
}
