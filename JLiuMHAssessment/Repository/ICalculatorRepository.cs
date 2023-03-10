namespace JLiuMHAssessment.Repository
{
    public interface ICalculatorRepository
    {
        public decimal GetLoanValuationRatio(Models.Loan incomingdata);
    }
}