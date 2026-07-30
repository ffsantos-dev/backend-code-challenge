
using Medications.Api.Persistence;
using Medications.Api.Persistence.Repositories.Abstractions;

namespace Medications.Api.Repositories;

public class MedicationsRepository : IMedicationsRepository
{
    public MedicationsRepository (MedicationsDbContext dbContext)
    {
        
    }
}