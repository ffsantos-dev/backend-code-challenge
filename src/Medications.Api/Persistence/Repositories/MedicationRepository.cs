using Medications.Api.Domain;
using Medications.Api.Domain.Exceptions;
using Medications.Api.Persistence.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Medications.Api.Persistence.Repositories;

public class MedicationRepository : IMedicationRepository
{
    private readonly DbSet<MedicationModel> _medications;
    private readonly MedicationsDbContext _context;
    private readonly ILogger<MedicationRepository> _logger;

    public MedicationRepository(MedicationsDbContext dbContext, ILogger<MedicationRepository> logger)
    {
        _logger = logger;
        _context = dbContext;
        _medications = dbContext.Medications;
    }

    public async Task<MedicationModel> CreateAsync(MedicationModel model)
    {
        try
        {
            _logger.LogDebug("Create Medication");
            MedicationModel response = (await _medications.AddAsync(model)).Entity;
            await _context.SaveChangesAsync();
            return response;
        }
        catch (DbUpdateException)
        {
            throw new DuplicateEntityException($"Medication with name '{model.Name}' already exists!");
        }
    }

    public async Task DeleteAsync(MedicationModel model)
    {
        _logger.LogDebug("Delete Medication");
        _medications.Remove(model);
        await _context.SaveChangesAsync();
    }

    public async Task<MedicationModel?> ExistsByNameAsync(string name)
    {
        _logger.LogDebug("Get By Name Medication");
        return await _medications
            .Where(medication => medication.Name == name)
            .FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyCollection<MedicationModel>> GetAllAsync()
    {
        _logger.LogDebug("Get All Medication");
        return await _medications.ToListAsync();
    }

    public async Task<MedicationModel?> GetByIdAsync(Guid id)
    {
        _logger.LogDebug("Get By Id Medication");
        return await _medications
            .Where(medication => medication.Id == id)
            .FirstOrDefaultAsync();
    }
}
