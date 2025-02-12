using FinancialSavingsCalculator.Api.Application.Models;

namespace FinancialSavingsCalculator.Api.Application.Services
{
    public interface ICalculationServices
    {
        public List<YearlySavingsResult> CalculateSavings(SavingsModel model);

    }
}
