using System;

namespace IrrationalNumbers.Logic.Expansions
{
    public class ExponentTaylorExpansion : IBasicFunctionExpansion
    {
        private IBasicFunctionExpansion _anyBaseExpansion;

        public ExponentTaylorExpansion()
        {
            _anyBaseExpansion = new ExponentialWithAnyBaseExpansion(3);
        }

        public RemainderResult EvaluateN(int wantedRemainder, BigDecimal x)
        {
            BigDecimal c = 0;
            if (x > 0)
                c = x;

            BigDecimal absX = BigDecimal.Abs(x);
            BigDecimal estimatedCoefficient = _anyBaseExpansion.ExpandFunction(wantedRemainder, c);

            for (int i = 1; ; ++i)
            {
                if (estimatedCoefficient * BigDecimal.PowBig(absX, i + 1) < Utils.CalculateFactorial(i + 1) * Math.Pow(10, wantedRemainder))
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

            return result + remainderResult.Remainder;
        }
    }
}
