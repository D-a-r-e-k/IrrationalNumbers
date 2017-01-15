using System;
using System.Linq;
using System.Numerics;
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

        public static ParameterNormalizationResult NormalizeParameter(BigDecimal parameter, BigDecimal alpha, int remainder)
        {
            var result = new ParameterNormalizationResult();
            var reciprocal = 1/alpha;
            var exponentWithAnyBase = new ExponentialWithAnyBaseExpansion(0);

            parameter = BigDecimal.Abs(parameter);

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
                    result.FinalMultiplier = 1 * FinalMultiPlyerSign(parameter, alpha);
                }
                return result;
            }


            if (alpha < 1 && alpha > 0)
            {
                for (int i = 2;; i+=10)
                {
                   // var powed = Math.Pow(i, Math.Floor((double)reciprocal)); // TODO: think about floor for BigDecimal
                    exponentWithAnyBase.SetBase(i);

                    var powed = exponentWithAnyBase.ExpandFunction(remainder - 1, reciprocal);
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
                        result.FinalMultiplier = i * FinalMultiPlyerSign(parameter, alpha);
                        break;
                    }

                }
            }
            else if (alpha >=1 || alpha <= -1)
            {
                var divideBy = parameter * 3 / 4;
                var divisionResult = parameter / divideBy;

                exponentWithAnyBase.SetBase(divideBy);
                result.FinalMultiplier = exponentWithAnyBase.ExpandFunction(-7, alpha) * FinalMultiPlyerSign(parameter, alpha);
                //result.FinalMultiplier = Math.Pow(divideBy, alpha);
                result.NormalizedParameter = divisionResult - 1;
            }

            return result;
        }

        public static int FinalMultiPlyerSign(BigDecimal par, BigDecimal alpha)
        {
            if (par > 0)
                return 1;
            else
            {
                if (alpha.Mantissa.IsEven)
                    return 1;
                else
                {
                    return -1;
                }
            }
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
