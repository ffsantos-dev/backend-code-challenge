
namespace Medications.Api.DTOs;

public sealed class MedicationResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public int Quantity { get; init; }
    public DateTime CreationDate { get; init; }
}
