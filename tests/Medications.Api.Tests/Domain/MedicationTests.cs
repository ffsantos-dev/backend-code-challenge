using Medications.Api.Domain;
using Medications.Api.Domain.Exceptions;
using NUnit.Framework;

namespace Medications.Api.Tests.Domain;

[TestFixture]
public class MedicationTests
{
    [TestCase(0)]
    [TestCase(-1)]
    [TestCase(-100)]
    public void Create_ShouldThrowBusinessRuleException_WhenQuantityIsInvalid(int quantity, string name = "Paracetamol")
    {
        Assert.Throws<BusinessRuleException>(() => {Medication.Create(Guid.NewGuid(), name, quantity);});
    }

    [TestCase("")]
    [TestCase(" ")]
    [TestCase(null)]
    public void Create_ShouldThrowBusinessRuleException_WhenNameIsInvalid(string name, int quantity = 1)
    {
        Assert.Throws<BusinessRuleException>(() => {Medication.Create(Guid.NewGuid(), name, quantity);});
    }

    [TestCase("Paracetamol", 20)]
    [TestCase("Ibuprofen", 70)]
    [TestCase("Aspirin", 100)]
    public void Create_ShouldCreateMedication_WhenParametersAreValid(string name, int quantity)
    {
        Guid id = Guid.NewGuid();

        Medication medication = Medication.Create(id, name, quantity);

        Assert.That(medication.Id, Is.EqualTo(id));
        Assert.That(medication.Name,  Is.EqualTo(name));
        Assert.That(medication.Quantity, Is.EqualTo(quantity));
        Assert.That(medication.CreationDate, Is.Not.EqualTo(default(DateTime)));
    }
}
