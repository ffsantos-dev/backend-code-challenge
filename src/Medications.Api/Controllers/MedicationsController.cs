using Medications.Api.DTOs;
using Medications.Api.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Medications.Api.Controllers;

[ApiController]
[Route("api/medication")]
public class MedicationsController : ControllerBase
{
    private readonly IMedicationsService _service;

    public MedicationsController(IMedicationsService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<MedicationResponse>>> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpPost]
    public async Task<ActionResult<MedicationResponse>> Post([FromBody] CreateMedicationRequest request)
    {
        return Ok(await _service.CreateAsync(request));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }
}
