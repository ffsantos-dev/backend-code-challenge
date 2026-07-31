
using Medications.Api.Domain;
using Medications.Api.Persistence.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Medications.Api.Persistence.Repositories;

public class MedicationsRepository : IMedicationsRepository
{
    private readonly DbSet<MedicationModel> _medications;
    private readonly MedicationsDbContext _context;
    private readonly ILogger<MedicationsRepository> _logger;

    public MedicationsRepository (MedicationsDbContext dbContext, ILogger<MedicationsRepository> logger)
    {
        _logger = logger;
        _context = dbContext;
        _medications = dbContext.Medications;
    }

    public async Task<MedicationModel> CreateAsync(MedicationModel model)
    {
        _logger.LogDebug("Create Medication\n");
        MedicationModel response = (await _medications.AddAsync(model)).Entity;
        await _context.SaveChangesAsync();
        return response;
    }

    public async Task DeleteAsync(MedicationModel model)
    {
        _logger.LogDebug("Delete Medication\n");
        _medications.Remove(model);
        await _context.SaveChangesAsync();
        return;
    }

    public async Task<MedicationModel?> ExistsByNameAsync(string name)
    {
        _logger.LogDebug("Get By Id Medication\n");
        return await _medications
            .Where(medication => medication.Name == name)
            .FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyCollection<MedicationModel>> GetAllAsync()
    {
        _logger.LogDebug("Get All Medication\n");
        return await _medications.ToListAsync();
    }

    public async Task<MedicationModel?> GetByIdAsync(Guid id)
    {
        _logger.LogDebug("Get By Id Medication\n");
        return await _medications
            .Where(medication => medication.Id == id)
            .FirstOrDefaultAsync();
    }
}