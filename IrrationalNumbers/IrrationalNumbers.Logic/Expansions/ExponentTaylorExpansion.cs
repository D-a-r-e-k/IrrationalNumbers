using System;

namespace IrrationalNumbers.Logic.Expansions
{
    public class ExponentTaylorExpansion : IBasicFunctionExpansion
    {
        public RemainderResult EvaluateN(int wantedRemainder, BigDecimal x)
        {
            BigDecimal c = 0;
            if (x > 0)
                c = x;

            BigDecimal absX = BigDecimal.Abs(x);

            for (int i = 1; ; ++i)
            {
                // TODO: change to a^x expansion
                if (Math.Pow(3, (double) c) * BigDecimal.PowBig(absX, i + 1) < Utils.CalculateFactorial(i + 1) * Math.Pow(10, wantedRemainder))
                    return new RemainderResult()
                    {
                        Remainder = Math.Pow(3, (double) c) / Utils.CalculateBigDecimalFactorial(i + 1) * BigDecimal.PowBig(x, i + 1),
                        RemainderOrder = i
                    };
            }
        }

        public BigDecimal ExpandFunction(int wantedRemainder, BigDecimal x)
        {
            RemainderResult remainderResult = EvaluateN(wantedRemainder, x);

            BigDecimal result = 1;
            for (int i = 1; i <= remainderResult.RemainderOrder; ++i)
            {
                BigDecimal ithCoeficientBig = BigDecimal.PowBig(x,i) / Utils.CalculateBigDecimalFactorial(i);
                result += ithCoeficientBig;
            }

            return result;
        }
    }
}
