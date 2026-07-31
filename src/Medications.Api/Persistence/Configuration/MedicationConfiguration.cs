using Medications.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medications.Api.Persistence.DataModel;

public class MedicationConfiguration : IEntityTypeConfiguration<MedicationModel>
{
    public void Configure(EntityTypeBuilder<MedicationModel> builder)
    {
        // Table Name
        builder.ToTable("Medication");

        // Primary Key
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(m => m.Name)
            .IsUnique();

        builder.Property(m => m.Quantity)
            .IsRequired();

        builder.Property(m => m.CreationDate)
            .IsRequired();
    }
}
