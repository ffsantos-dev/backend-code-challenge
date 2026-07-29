using Medications.Api.DTOs;

namespace Medications.Api.Models;

class Medication 
{
    private Guid Id; 
    private string Name;
    private int Quantity;
    private DateTime CreationDate;

    private Medication(Guid id, string name, int quantity, DateTime creationDate)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        CreationDate = creationDate;
    }

    public static Medication Create(CreateMedicationDTO createMedicationDTO)
    {   
        
        return new Medication(
            new Guid(),
            createMedicationDTO.Name,
            createMedicationDTO.Quantity,
            createMedicationDTO.CreationDate);
    }
} 
