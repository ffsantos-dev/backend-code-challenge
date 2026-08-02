using Medications.Api.Domain.Exceptions;

namespace Medications.Api.Domain;

public class Medication
{
    public Guid Id { get; }
    public string Name { get; }
    public int Quantity { get; }
    public DateTime CreationDate { get; }

    private Medication(Guid id, string name, int quantity, DateTime creationDate)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        CreationDate = creationDate;
    }

    public static Medication Create(Guid id, string name, int quantity)
    {   
        if (quantity < 1)
        {
            throw new BusinessRuleException("The quantity must be greater than zero!");
        }

        if (name == null || name.Trim().Length < 1)
        {
            throw new BusinessRuleException("The name can't be empty");
        }
        
        return new Medication(
            id,
            name,
            quantity,
            DateTime.UtcNow);
    }
} 
