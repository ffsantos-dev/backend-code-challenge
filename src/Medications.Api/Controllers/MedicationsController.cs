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
    public IActionResult GetAll()
    {
        _service.GetAllAsync();
        return Ok();
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateMedicationRequest request)
    {
        _service.CreateAsync(request);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        _service.DeleteAsync(id);
        return Ok();
    }
}
