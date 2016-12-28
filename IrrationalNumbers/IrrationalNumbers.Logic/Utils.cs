namespace IrrationalNumbers.Logic
{
    public static class Utils
    {
        public static double CalculateFactorial(int n)
        {
            double result = 1;
            for (int i = 1; i <= n; ++i)
                result *= i;
            return result;
        }

        public static double CalculateFactorial(float start, int n)
        {
            double result = start;
            for (int i = 1; i < n; ++i)
                result *= start - i;
            return result;
        }

        public static BigDecimal CalculateBigDecimalFactorial(int n)
        {
            BigDecimal result = 1;
            for (int i = 1; i <= n; ++i)
                result *= i;
            return result;
        }
        /// <summary>
        ///Metodas, kuris pavercia bet koki saknies parametra i israiska 1 + x. kur |x| maziau uz 1
        ///Pvz : 100 = (1 + 1/3) * 75
        /// </summary>
        /// <param name="parameter">Duotas parametras (pvz. x = 100)</param>
        /// <returns></returns>
        public static ParameterNormalizationResult NormalizeParameter(double parameter)
        {
            var divideBy = parameter * 3 / 4;

            var divisionResult = parameter / divideBy;

            return new ParameterNormalizationResult()
            {
                FinalMultiplier = divideBy,
                NormalizedParameter = divisionResult - 1
            };
        }
    }
}
