
namespace Medications.Api.Domain.Exceptions;

public class BusinessRuleException : Exception
{
    public BusinessRuleException(string message) : base (message)
    {
    }
}