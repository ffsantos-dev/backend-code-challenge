using System.ComponentModel.DataAnnotations;

namespace Medications.Api.DTOs;

public class CreateMedicationRequest
{
    [Required]
    public string Name { get; init; } = string.Empty;

    [Required]
    [Range(1, int.MaxValue)]
    public int Quantity { get; init; }
}