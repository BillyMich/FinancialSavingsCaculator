using System.Diagnostics;
using System.Security.Claims;

namespace FinancialSavingsCalculator.Api.Logging
{
    public class LoggerService : ILoggerService
    {
        private readonly ILogCommands _logCommands;

        public LoggerService(ILogCommands logCommands)
        {
            _logCommands = logCommands;
        }

        public async Task LogErrorAsync(string message, ErrorStatus ErrorStatusId, Exception exceptionm)
        {
            var log = new LogDto
            {
                Message = message,
                ErrorStatusId = (byte)ErrorStatusId,
                ExceptionMessage = exceptionm.ToString(),
                CreatedAt = DateTimeOffset.Now,
                TraceId = Activity.Current?.TraceId.ToString() ?? "N/A",
            };

            await _logCommands.InsertNewLogAsync(log);

        }

        public async Task LogErrorAsync(string message, ErrorStatus ErrorStatusId, Exception exception, ClaimsPrincipal claimsPrincipal)
        {
            var log = new LogDto
            {
                Message = message,
                ErrorStatusId = (byte)ErrorStatusId,
                ExceptionMessage = exception?.ToString(),
                CreatedAt = DateTimeOffset.Now,
                TraceId = Activity.Current?.TraceId.ToString() ?? "N/A",
                UserName = claimsPrincipal.Identity?.Name ?? "N/A",

            };

            await _logCommands.InsertNewLogAsync(log);

        }

        public async Task LogErrorAsync(string message, Exception? exception)
        {
            var log = new LogDto
            {
                Message = message,
                ErrorStatusId = (byte)ErrorStatus.Error,
                ExceptionMessage = exception?.ToString(),
                CreatedAt = DateTimeOffset.Now,
                TraceId = Activity.Current?.TraceId.ToString() ?? "N/A",
            };

            await _logCommands.InsertNewLogAsync(log);
        }

        public async Task LogErrorAsync(string message, Exception? exception, ClaimsPrincipal claimsPrincipal)
        {

            var log = new LogDto
            {
                Message = message,
                ErrorStatusId = (byte)ErrorStatus.Error,
                ExceptionMessage = exception?.ToString(),
                CreatedAt = DateTimeOffset.Now,
                TraceId = Activity.Current?.TraceId.ToString() ?? "N/A",
                UserName = claimsPrincipal.Identity?.Name ?? "N/A",
            };

            await _logCommands.InsertNewLogAsync(log);
        }

        public async Task LogInformationAsync(string message)
        {
            var log = new LogDto
            {
                Message = message,
                ErrorStatusId = (byte)ErrorStatus.Information,
                CreatedAt = DateTimeOffset.Now,
                TraceId = Activity.Current?.TraceId.ToString() ?? "N/A",

            };

            await _logCommands.InsertNewLogAsync(log);
        }

        public async Task LogInformationAsync(string message, ClaimsPrincipal claimsPrincipal)
        {
            var log = new LogDto
            {
                Message = message,
                ErrorStatusId = (byte)ErrorStatus.Information,
                CreatedAt = DateTimeOffset.Now,
                TraceId = Activity.Current?.TraceId.ToString() ?? "N/A",
                UserName = claimsPrincipal.Identity?.Name ?? "N/A",
            };

            await _logCommands.InsertNewLogAsync(log);
        }

        public async Task LogWarningAsync(string message)
        {
            var log = new LogDto
            {
                Message = message,
                ErrorStatusId = (byte)ErrorStatus.Warning,
                CreatedAt = DateTimeOffset.Now,
                TraceId = Activity.Current?.TraceId.ToString() ?? "N/A",
            };

            await _logCommands.InsertNewLogAsync(log);
        }

        public async Task LogWarningAsync(string message, ClaimsPrincipal claimsPrincipal)
        {
            var log = new LogDto
            {
                Message = message,
                ErrorStatusId = (byte)ErrorStatus.Warning,
                CreatedAt = DateTimeOffset.Now,
                TraceId = Activity.Current?.TraceId.ToString() ?? "N/A",
                UserName = claimsPrincipal.Identity?.Name ?? "N/A",
            };

            await _logCommands.InsertNewLogAsync(log);
        }
    }
}
