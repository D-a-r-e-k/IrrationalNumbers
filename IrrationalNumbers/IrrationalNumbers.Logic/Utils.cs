using System;
using IrrationalNumbers.Logic.Expansions;

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

        public static ParameterNormalizationResult NormalizeParameter(BigDecimal parameter, double alpha)
        {
            var result = new ParameterNormalizationResult();
            var reciprocal = 1/alpha;
            var exponentWithAnyBase = new ExponentialWithAnyBaseExpansion(0);

            if (parameter < 2)
            {
                if (parameter > 1)
                {
                    result.NormalizedParameter = parameter - 1;
                    result.FinalMultiplier = 1;
                }
                else
                {
                    result.NormalizedParameter = parameter - 1;
                    result.FinalMultiplier = 1;
                }
                return result;
            }


            if (alpha < 1 && alpha > 0)
            {
                for (int i = 2;; i+=10)
                {
                    exponentWithAnyBase.SetBase(i);
                    var powed = Math.Pow(i, Math.Floor(reciprocal));

                    var parameterDivided = parameter/powed;

                    if (parameterDivided < 2)
                    {
                        if (parameterDivided < 1)
                        {
                            var complementToOne = 1 - parameterDivided;
                            result.NormalizedParameter = -complementToOne;
                        }
                        else
                        {
                            result.NormalizedParameter = parameterDivided - 1;
                        }
                        result.FinalMultiplier = i;
                        break;
                    }

                }
            }
            else if (alpha >=1 || alpha <= -1)
            {
                var divideBy = parameter * 3 / 4;
                var divisionResult = parameter / divideBy;

                exponentWithAnyBase.SetBase(divideBy);
                result.FinalMultiplier = exponentWithAnyBase.ExpandFunction(-7, alpha);
                //result.FinalMultiplier = Math.Pow(divideBy, alpha);
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
