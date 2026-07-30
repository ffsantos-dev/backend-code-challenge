using System.ComponentModel.DataAnnotations;

namespace Medications.Api.DTOs;

public class CreateMedicationRequest
{
    [Required]
    public string Name { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
}