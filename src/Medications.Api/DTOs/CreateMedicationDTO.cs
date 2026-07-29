namespace Medications.Api.DTOs;

public class CreateMedicationDTO
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public DateTime CreationDate { get; set; }

    public CreateMedicationDTO(string name, int quantity, DateTime creationDate)
    {
        Name = name;
        Quantity = quantity;
        CreationDate = creationDate;
    }
}