
namespace Medications.Api.Domain.Exceptions;

public class DuplicateEntityException : Exception
{
    public DuplicateEntityException(string message) : base (message)
    {
    }
}