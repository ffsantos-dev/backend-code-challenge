
using Medications.Api.Domain;

namespace Medications.Api.Persistence.Repositories.Abstractions;
public interface IMedicationsRepository
{
    Task<MedicationModel> CreateAsync(MedicationModel model);
    Task DeleteAsync(MedicationModel model);
    Task<IReadOnlyCollection<MedicationModel>> GetAllAsync();
    Task<MedicationModel?> GetByIdAsync(Guid id);
    Task<MedicationModel?> ExistsByNameAsync(string name);
}