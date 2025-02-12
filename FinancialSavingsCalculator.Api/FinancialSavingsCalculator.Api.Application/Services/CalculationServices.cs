using FinancialSavingsCalculator.Api.Application.Models;

namespace FinancialSavingsCalculator.Api.Application.Services
{
    public class CalculationServices : ICalculationServices
    {
        public CalculationServices() { }

        public List<YearlySavingsResult> CalculateSavings(SavingsModel model)
        {
            var results = new List<YearlySavingsResult>();
            decimal totalAmount = model.InitialAmount;
            decimal monthlyRate = model.AnnualPercentageYield / 12 / 100;
            decimal totalDeposited = 0;

            for (int year = 1; year <= model.Years; year++)
            {
                var yearlyResult = CalculateYearlySavings(model, ref totalAmount, monthlyRate, ref totalDeposited, year);
                results.Add(yearlyResult);
            }

            return results;
        }

        private YearlySavingsResult CalculateYearlySavings(SavingsModel model, ref decimal totalAmount, decimal monthlyRate, ref decimal totalDeposited, int year)
        {
            decimal yearlyDeposited = 0;
            decimal yearlyInterest = 0;
            decimal interest = 0;

            for (int month = 1; month <= 12; month++)
            {
                totalAmount += model.MonthlyDeposit;
                yearlyDeposited += model.MonthlyDeposit;
                totalDeposited += model.MonthlyDeposit;

                interest = totalAmount * monthlyRate;
                totalAmount += interest;
                yearlyInterest += interest;
            }

            return new YearlySavingsResult
            {
                Year = year,
                TotalAmount = totalAmount,
                DepositedAmount = totalDeposited,
                InterestEarned = yearlyInterest,
                TotalInterestEarned = interest
            };
        }
    }
}
