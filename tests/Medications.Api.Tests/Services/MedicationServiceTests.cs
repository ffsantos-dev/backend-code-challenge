using Medications.Api.Domain;
using Medications.Api.Domain.Exceptions;
using Medications.Api.DTOs;
using Medications.Api.Persistence.Repositories.Abstractions;
using Medications.Api.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Medications.Api.Tests.Services;

[TestFixture]
public class MedicationServiceTests
{
    [TestCase("Ibuprofen", 10)]
    [TestCase("Paracetamol", 50)]
    public async Task CreateAsync_ShouldThrowDuplicateEntityException_WhenMedicationNameAlreadyExists(string name, int quantity)
    {
        var request = new CreateMedicationRequest
        {
            Name = name,
            Quantity = quantity
        };

        var model = new MedicationModel
        {
            Id = Guid.NewGuid(),
            Name = name,
            Quantity = quantity,
            CreationDate = DateTime.UtcNow
        };

        var repository = new Mock<IMedicationRepository>();
        var logger = new Mock<ILogger<MedicationService>>();

        repository.Setup(repository => repository.ExistsByNameAsync(request.Name))
            .ReturnsAsync(model);
        
        var service = new MedicationService(repository.Object, logger.Object);

        Assert.ThrowsAsync<DuplicateEntityException>(async () => {await service.CreateAsync(request);});

        repository.Verify(repository => repository.ExistsByNameAsync(request.Name), Times.Once);
    }

    [TestCase("Ibuprofen", 10)]
    [TestCase("Paracetamol", 50)]
    public async Task CreateAsync_ShouldCreateMedication_WhenParametersAreValid(string name, int quantity)
    {
        var request = new CreateMedicationRequest
        {
            Name = name,
            Quantity = quantity
        };

        var repositoryMock = new Mock<IMedicationRepository>();
        var loggerMock = new Mock<ILogger<MedicationService>>();

        repositoryMock.Setup(repository => repository.ExistsByNameAsync(request.Name))
            .ReturnsAsync((MedicationModel?) null);

        repositoryMock.Setup(repository => repository.CreateAsync(It.IsAny<MedicationModel>()))
            .ReturnsAsync((MedicationModel model) => model);
        
        var service = new MedicationService(repositoryMock.Object, loggerMock.Object);

        MedicationResponse response = await service.CreateAsync(request);

        Assert.That(response.Name, Is.EqualTo(name));
        Assert.That(response.Quantity, Is.EqualTo(quantity));
        Assert.That(response.Id, Is.Not.EqualTo(Guid.Empty));

        repositoryMock.Verify(repository => repository.ExistsByNameAsync(request.Name), Times.Once);

        repositoryMock.Verify(repository => repository.CreateAsync(It.Is<MedicationModel>(
            model => model.Name == name 
            && model.Quantity == quantity 
            && model.Id != Guid.Empty)), Times.Once);
    }
}
