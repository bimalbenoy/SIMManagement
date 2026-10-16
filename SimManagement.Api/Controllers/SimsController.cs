
using Microsoft.AspNetCore.Mvc;
using SimManagement.Application.DTOs;
using SimManagement.Application.Interfaces;

namespace SimManagement.Api.Controllers;

[ApiController]
[Route("api/v1/sims")]
public class SimsController : ControllerBase
{
    private readonly ISimService _simService;

    public SimsController(ISimService simService)
    {
        _simService = simService;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<SimResponseDto>> GetById(int id)
    {
        var sim = await _simService.GetByIdAsync(id);

        if (sim is null)
        {
            return NotFound();
        }

        return Ok(sim);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<SimResponseDto>>> GetAll()
    {
        var sims = await _simService.GetAllAsync();
        return Ok(sims);
    }

    [HttpPost]
    public async Task<ActionResult<SimResponseDto>> Create(
        [FromBody] CreateSimDto dto)
    {
        var sim = await _simService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = sim.Id },
            sim);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] UpdateSimDto dto)
    {
        var updated = await _simService.UpdateAsync(id, dto);

        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _simService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
