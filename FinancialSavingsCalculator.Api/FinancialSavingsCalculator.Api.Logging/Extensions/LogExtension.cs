namespace FinancialSavingsCalculator.Api.Logging
{
    public static class LogExtension
    {
        public static Log ToLog(this LogDto log)
        {
            return new Log
            {
                Message = log.Message,
                ErrorStatusId = log.ErrorStatusId,
                ExceptionMessage = log.ExceptionMessage,
                CreatedAt = log.CreatedAt,
                TraceId = log.TraceId,
                Initiator = log.UserName,

            };
        }
    }
}
