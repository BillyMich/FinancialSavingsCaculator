using System.Security.Claims;

namespace FinancialSavingsCalculator.Api.Logging;
public interface ILoggerService
{
    Task LogErrorAsync(string message, Exception? exception);

    Task LogErrorAsync(string message, Exception? exception, ClaimsPrincipal claimsPrincipal);

    Task LogInformationAsync(string message);

    Task LogInformationAsync(string message, ClaimsPrincipal claimsPrincipal);
    Task LogWarningAsync(string message);
    Task LogWarningAsync(string message, ClaimsPrincipal claimsPrincipal);
}

