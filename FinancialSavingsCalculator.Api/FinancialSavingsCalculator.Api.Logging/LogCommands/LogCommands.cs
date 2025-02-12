namespace FinancialSavingsCalculator.Api.Logging
{
    public class LogCommands : ILogCommands
    {
        private readonly IDbContextFactory _dbContextFactory;

        public LogCommands(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<bool> InsertNewLogAsync(LogDto log)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                try
                {
                    var logEntity = log.ToLog();


                    await context.AddAsync(logEntity);
                    await context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    // Log the exception details for further analysis
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
    }
}
