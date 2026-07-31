using Microsoft.AspNetCore.Diagnostics;

namespace Medications.Api.Domain.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base (message)
    {
    }
}