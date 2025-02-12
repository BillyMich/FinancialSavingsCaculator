using FinancialSavingsCalculator.Api.Application.Models;
using FinancialSavingsCalculator.Api.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancialSavingsCalculator.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculationsController : ControllerBase
    {
        private readonly ICalculationServices _calculationServices;

        public CalculationsController(ICalculationServices calculationServices)
        {
            _calculationServices = calculationServices;
        }

        [HttpPost("CalculateSavings")]
        public ActionResult<YearlySavingsResult> CalculateSavings([FromBody] SavingsModel request)
        {
            var result = _calculationServices.CalculateSavings(request);
            return Ok(result);
        }

    }

}