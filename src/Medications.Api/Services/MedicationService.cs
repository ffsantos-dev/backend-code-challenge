using Medications.Api.Domain;
using Medications.Api.Domain.Exceptions;
using Medications.Api.DTOs;
using Medications.Api.Persistence.Repositories.Abstractions;
using Medications.Api.Services.Abstractions;

namespace Medications.Api.Services;

public class MedicationService : IMedicationService
{
    private readonly IMedicationRepository _repository;
    private readonly ILogger<MedicationService> _logger;

    public MedicationService(IMedicationRepository repository, ILogger<MedicationService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<MedicationResponse> CreateAsync(CreateMedicationRequest request)
    {
        _logger.LogDebug("Create Medication");
        MedicationModel? model = await _repository.ExistsByNameAsync(request.Name);
        if (model != null)
        {
            throw new DuplicateEntityException($"Medication with name '{request.Name}' already exists!");
        }

        Medication medication = Medication.Create(Guid.NewGuid(), request.Name, request.Quantity);
        return MedicationMapper.ToResponse(await _repository.CreateAsync(MedicationMapper.ToModel(medication)));
    }

    public async Task DeleteAsync(Guid id)
    {
        _logger.LogDebug("Delete Medication");
        MedicationModel? model = await _repository.GetByIdAsync(id);
        if (model is null)
        {
            throw new NotFoundException($"Medication with id '{id}' was not found!");
        }

        await _repository.DeleteAsync(model);
    }

    public async Task<IReadOnlyCollection<MedicationResponse>> GetAllAsync()
    {
        _logger.LogDebug("Get All Medication");
        IReadOnlyCollection<MedicationModel> medications = await _repository.GetAllAsync();
        return medications.Select(model => MedicationMapper.ToResponse(model)).ToList();
    }
}
