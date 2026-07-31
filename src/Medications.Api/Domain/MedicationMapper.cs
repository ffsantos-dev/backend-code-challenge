
using Medications.Api.DTOs;

namespace Medications.Api.Domain;

class MedicationMapper
{
    public static MedicationModel ToModel(Medication domain)
    {
        return new MedicationModel
        {
            Id = domain.Id,
            Name = domain.Name,
            Quantity = domain.Quantity,
            CreationDate = domain.CreationDate
        };
    }

    public static MedicationResponse ToResponse(MedicationModel model)
    {
        return new MedicationResponse
        {
            Id = model.Id,
            Name = model.Name,
            Quantity = model.Quantity,
            CreationDate = model.CreationDate
        };
    }

    public static MedicationResponse ToResponse(Medication domain)
    {
        return new MedicationResponse
        {
            Id = domain.Id,
            Name = domain.Name,
            Quantity = domain.Quantity,
            CreationDate = domain.CreationDate
        };
    }
} 
