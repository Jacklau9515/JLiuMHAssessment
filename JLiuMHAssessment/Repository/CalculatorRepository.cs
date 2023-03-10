using System;

namespace JLiuMHAssessment.Repository
{
    public class CalculatorRepository : ICalculatorRepository
    {
        public decimal GetLoanValuationRatio(Models.Loan incomingdata)
        {
            decimal LVR;

            try
            {
                decimal propertyVal = Convert.ToDecimal(incomingdata.PropertyValue);
                decimal loanamountVal = Convert.ToDecimal(incomingdata.LoanAmount);

                LVR = loanamountVal / propertyVal;
            }
            catch (Exception)
            {
                throw;
            }

            return LVR;
        }
    }
}
