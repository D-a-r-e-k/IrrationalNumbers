using System;

namespace IrrationalNumbers.Logic.Expansions
{
    public class ExponentialWithAnyBaseExpansion : IBasicFunctionExpansion
    {
        private readonly IBasicFunctionExpansion _naturalLogarithmExpansion;
        private readonly double _exponentBase;

        public ExponentialWithAnyBaseExpansion(double exponentBase)
        {
            _naturalLogarithmExpansion = new NaturalLogarithmExpansion();
            _exponentBase = exponentBase;
        }

        public RemainderResult EvaluateN(int wantedRemainder, BigDecimal x)
        {
            for (int i = 1; ; ++i)
            {
                BigDecimal expandedLn = _naturalLogarithmExpansion.ExpandFunction(wantedRemainder, (double) _exponentBase);

                if (BigDecimal.PowBig(x, i) * BigDecimal.PowBig(expandedLn, i) 
                     < Math.Pow(10, wantedRemainder) * Utils.CalculateBigDecimalFactorial(i))
                    return new RemainderResult()
                    {
                        Remainder = BigDecimal.PowBig(x, i) * BigDecimal.PowBig(expandedLn, i) / 
                            Utils.CalculateBigDecimalFactorial(i),
                        RemainderOrder = i
                    };
            }
        }

        public BigDecimal ExpandFunction(int wantedRemainder, double x)
        {
            RemainderResult remainderResult = EvaluateN(wantedRemainder, x);

            BigDecimal result = 1;
            for (int i = 1; i <= remainderResult.RemainderOrder; ++i)
            {
                BigDecimal expandedLn = _naturalLogarithmExpansion.ExpandFunction(wantedRemainder, (double)_exponentBase);

                BigDecimal ithCoeficientBig = BigDecimal.PowBig(x, i) * BigDecimal.PowBig(expandedLn, i) /
                            Utils.CalculateBigDecimalFactorial(i);

                result += ithCoeficientBig;
            }

            return result;
        }
    }
}
