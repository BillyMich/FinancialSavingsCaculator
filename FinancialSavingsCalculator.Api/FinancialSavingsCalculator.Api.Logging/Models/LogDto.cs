
namespace FinancialSavingsCalculator.Api.Logging
{
    public class LogDto
    {
        public string Message { get; set; }
        public byte ErrorStatusId { get; set; }
        public string ExceptionMessage { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string TraceId { get; set; }
        public string UserName { get; set; }
    }
}
