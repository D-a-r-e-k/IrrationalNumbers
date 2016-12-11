using System;


namespace IrrationalNumbers.Logic.Expansions
{
    public class ExponentTaylorExpansion : IBasicFunctionExpansion
    {
        public RemainderResult EvaluateN(int wantedRemainder, double x)
        {
            double c = Math.Max(x, 0);
            double absX = Math.Abs(x);

            for (int i = 1; ; ++i)
            {
                if (Math.Pow(3, c) * Math.Pow(absX, i + 1) < Utils.CalculateFactorial(i + 1) * Math.Pow(10, wantedRemainder))
                    return new RemainderResult()
                    {
                        Remainder = Math.Pow(3, c) / Utils.CalculateFactorial(i + 1) * Math.Pow(x, i + 1),
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
                BigDecimal ithCoeficientBig = BigDecimal.PowBig(x,i) / Utils.CalculateBigDecimalFactorial(i);
                result += ithCoeficientBig;
            }

            return result;
        }
    }
}
