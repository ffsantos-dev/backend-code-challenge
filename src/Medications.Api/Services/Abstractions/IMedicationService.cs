
using Medications.Api.DTOs;

namespace Medications.Api.Services.Abstractions;
public interface IMedicationService
{
    Task<MedicationResponse> CreateAsync(CreateMedicationRequest request);
    Task DeleteAsync(Guid id);
    Task<IReadOnlyCollection<MedicationResponse>> GetAllAsync();
}