using JLiuMHAssessment.Models;
using JLiuMHAssessment.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JLiuMHAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorRepository _calculator;

        public CalculatorController(ICalculatorRepository calculator)
        {
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
        }

        [HttpPost]
        [Route("AddCalculation")]
        public IActionResult Post(Loan loandetails)
        {
            if (!ValidationModule.ValidateForPrice(loandetails.PropertyValue))
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Invalid Property Value");
            }

            if (!ValidationModule.ValidateForPrice(loandetails.LoanAmount))
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Invalid Loan Amount");
            }

            return Ok(_calculator.GetLoanValuationRatio(loandetails));
        }
    }
}
