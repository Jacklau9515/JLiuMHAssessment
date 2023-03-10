using JLiuMHAssessment.Controllers;
using JLiuMHAssessment.Models;
using JLiuMHAssessment.Repository;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;

namespace JLiuMHAssessmentTest
{
    public class UnitTest1 : IClassFixture<CalculatorRepository>
    {
        private readonly ICalculatorRepository _calculatorRepository;

        public UnitTest1(ICalculatorRepository calculatorRepository)
        {
            _calculatorRepository = calculatorRepository;
        }

        [Fact]
        public void FailingTest_NullPropertyVal()
        {
            Loan loan = new Loan();
            loan.PropertyValue = "";
            loan.LoanAmount = "800000";
            Assert.Equal(Convert.ToDecimal("0.8"), _calculatorRepository.GetLoanValuationRatio(loan));
        }

        [Fact]
        public void FailingTest_InvalidLoanAmountVal()
        {
            Loan loan = new Loan();
            loan.PropertyValue = "800000";
            loan.LoanAmount = "A$1000000";
            Assert.Equal(Convert.ToDecimal("0.8"), _calculatorRepository.GetLoanValuationRatio(loan));
        }

        [Fact]
        public void PassingingTest_EightyPercentLVR()
        {
            Loan loan = new Loan();
            loan.PropertyValue = "800000";
            loan.LoanAmount = "1000000";
            Assert.Equal(Convert.ToDecimal("0.8"), _calculatorRepository.GetLoanValuationRatio(loan));
        }
    }
}