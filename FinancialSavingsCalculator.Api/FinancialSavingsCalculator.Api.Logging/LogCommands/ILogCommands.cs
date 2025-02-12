namespace FinancialSavingsCalculator.Api.Logging
{
    public interface ILogCommands
    {
        Task<bool> InsertNewLogAsync(LogDto log);
    }
}
