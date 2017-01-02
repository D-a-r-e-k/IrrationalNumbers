using System;

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

        public static double CalculateFactorial(double start, int n)
        {
            double result = start;
            for (int i = 1; i < n; ++i)
                result *= start - i;
            return result;
        }

        public static BigDecimal CalculateBigDecimalFactorial(BigDecimal start, int n)
        {
            var result = start;
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

        public static ParameterNormalizationResult NormalizeParameter(double parameter, double alpha)
        {
            var result = new ParameterNormalizationResult();
            var reciprocal = 1/alpha;

            if (alpha < 1 && alpha > 0)
            {
                for (int i = 2;; i++)
                {
                    var powed = Math.Pow(i, reciprocal);
                    if (parameter/powed > 1 && parameter/powed < 2)
                    {
                        result.FinalMultiplier = i;
                        result.NormalizedParameter = parameter/powed - 1;
                        break;
                    }

                }
            }
            else if (alpha >=1 || alpha <= -1)
            {
                var divideBy = parameter * 3 / 4;
                var divisionResult = parameter / divideBy;

                result.FinalMultiplier = Math.Pow(divideBy, alpha);
                result.NormalizedParameter = divisionResult - 1;
            }

            return result;
        }


        public static double nCr(double n, double r)
        {
            // naive: return Factorial(n) / Factorial(r) * Factorial(n - r);
            return nPr(n, r) / CalculateFactorial((int)r);
        }

        public static double nPr(double n, double r)
        {
            // naive: return Factorial(n) / Factorial(n - r);
            return FactorialDivision(n, n - r);
        }

        private static double FactorialDivision(double topFactorial, double divisorFactorial)
        {
            double result = 1;
            for (double i = topFactorial; i > divisorFactorial; i--)
                result *= i;
            return result;
        }
    }
}
