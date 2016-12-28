
using System;

namespace IrrationalNumbers.Logic.Expansions
{
    public class SinTaylorExpansion : IBasicFunctionExpansion
    {

        public RemainderResult EvaluateN(int wantedRemainder, double x)
        {
            for (int i = 1;; ++i)
            {
                double possibleRemainder = Math.Pow(x, 2*i)/Utils.CalculateFactorial(2*i);

                if (Math.Abs(possibleRemainder) < Math.Pow(10, wantedRemainder))
                    return new RemainderResult()
                    {
                        Remainder = possibleRemainder,
                        RemainderOrder = i
                    };
            }
        }

        public BigDecimal ExpandFunction(int wantedRemainder, double x)
        {
            RemainderResult remainderResult = EvaluateN(wantedRemainder, x);
            BigDecimal result = remainderResult.Remainder;
            for (int i = 1; i <= remainderResult.RemainderOrder; ++i)
            {
                BigDecimal ithElement = BigDecimal.PowBig(-1, i - 1)*BigDecimal.PowBig(x, 2*i-1)/
                                        Utils.CalculateBigDecimalFactorial(2*i-1);
                result += ithElement;
            }
            return result;
        }
    }
}
