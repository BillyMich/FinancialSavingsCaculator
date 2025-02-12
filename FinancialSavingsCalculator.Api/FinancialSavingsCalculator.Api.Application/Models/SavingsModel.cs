namespace FinancialSavingsCalculator.Api.Application.Models
{
    public class SavingsModel
    {
        public decimal InitialAmount { get; set; }
        public decimal MonthlyDeposit { get; set; }
        public decimal AnnualPercentageYield { get; set; }
        public int Years { get; set; }

    }
}
