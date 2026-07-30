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
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.Quantity)
            .IsRequired();

        builder.Property(a => a.CreationDate)
            .IsRequired()
            .HasMaxLength(50);
    }
}
