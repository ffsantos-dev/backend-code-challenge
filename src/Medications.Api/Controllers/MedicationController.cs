using Medications.Api.DTOs;
using Medications.Api.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Medications.Api.Controllers;

[ApiController]
[Route("api/medication")]
public class MedicationController : ControllerBase
{
    private readonly IMedicationService _service;

    public MedicationController(IMedicationService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<MedicationResponse>>> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpPost]
    public async Task<ActionResult<MedicationResponse>> Create([FromBody] CreateMedicationRequest request)
    {
        return Created("/api/medication", await _service.CreateAsync(request));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
