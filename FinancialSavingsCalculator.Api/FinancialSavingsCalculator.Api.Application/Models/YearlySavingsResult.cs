namespace FinancialSavingsCalculator.Api.Application.Models
{
    public class YearlySavingsResult
    {
        public int Year { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DepositedAmount { get; set; }
        public decimal InterestEarned { get; set; }
        public decimal TotalInterestEarned { get; internal set; }
    }
}
