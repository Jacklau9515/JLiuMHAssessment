namespace JLiuMHAssessment
{
    public static class ValidationModule
    {
        public static bool ValidateForPrice(object PriceToValidate)
        {
            bool result = true;

            try
            {
                if (!(decimal.TryParse(PriceToValidate.ToString(), out decimal d) && d >= 0 && d * 100 == Math.Floor(d * 100)))
                {
                    result = false;
                }
            }
            catch
            {
                // Something was bad that caused the validation to fault.
                result = false;
            }

            return result;
        }
    }
}
