
using Medications.Api.Domain;
using Medications.Api.Persistence.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Medications.Api.Persistence.Repositories;

public class MedicationsRepository : IMedicationsRepository
{
    private readonly DbSet<MedicationModel> _medications;

    private readonly MedicationsDbContext _context;
    public MedicationsRepository (MedicationsDbContext dbContext)
    {
        _context = dbContext;
        _medications = dbContext.Medications;
    }

    public async Task<MedicationModel> CreateAsync(MedicationModel model)
    {
        MedicationModel response = (await _medications.AddAsync(model)).Entity;
        await _context.SaveChangesAsync();
        return response;
    }

    public async Task DeleteAsync(MedicationModel model)
    {
        _medications.Remove(model);
        await _context.SaveChangesAsync();
        return;
    }

    public async Task<IReadOnlyCollection<MedicationModel>> GetAllAsync()
    {
        return await _medications.ToListAsync();
    }

    public async Task<MedicationModel?> GetByIdAsync(Guid id)
    {
        return await _medications
        .Where(medication => medication.Id == id)
        .FirstOrDefaultAsync();
    }
}