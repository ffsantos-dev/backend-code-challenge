using Medications.Api.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Medications.Api.ExceptionHandling;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        switch (exception)
        {
            case NotFoundException:
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                break;
            case DuplicateEntityException:
                httpContext.Response.StatusCode = StatusCodes.Status409Conflict;
                break;
            case BusinessRuleException:
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                break;
            //case UnauthorizedException:
            //    httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            //    break;
            default:
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                break;
        }
        await httpContext.Response.WriteAsJsonAsync(new
        {
            message = exception.Message
        });
        return true;
    }
}
