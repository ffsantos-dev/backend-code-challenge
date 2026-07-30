using DotNetEnv;
using Medications.Api.Domain;
using Medications.Api.Persistence.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Medications.Api.Persistence;

public class MedicationsDbContext : DbContext
{
    public MedicationsDbContext(DbContextOptions<MedicationsDbContext> options) : base (options) {}
    public DbSet<MedicationModel> Medications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            Env.Load();
            optionsBuilder.UseMySQL(Env.GetString("DATABASE_URL"));
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MedicationConfiguration());
    }
}