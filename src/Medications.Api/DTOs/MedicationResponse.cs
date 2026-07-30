
namespace Medications.Api.DTOs;

public sealed class MedicationResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public DateTime CreationDate { get; set; }

    public MedicationResponse(Guid id, string name, int quantity, DateTime creationDate)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        CreationDate = creationDate;
    }
}
