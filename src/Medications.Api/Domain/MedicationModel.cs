
namespace Medications.Api.Domain;

public class MedicationModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public string CreationDate { get; set; }

    public MedicationModel(string id, string name, int quantity, string creationDate)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        CreationDate = creationDate;
    }
} 
