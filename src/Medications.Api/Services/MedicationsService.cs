
using Medications.Api.DTOs;
using Medications.Api.Services.Abstractions;

namespace Medications.Api.Services;

public class MedicationsService : IMedicationsService
{
    public async Task<MedicationResponse> CreateAsync(CreateMedicationRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyCollection<MedicationResponse>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
