using System;

namespace IrrationalNumbers.Logic.Expansions
{
    public class CosineTaylorExpansion : IBasicFunctionExpansion
    {
        public RemainderResult EvaluateN(int wantedRemainder, double x)
        {
            for (int i = 1; ; ++i)
            {
                BigDecimal possibleRemainder = BigDecimal.PowBig(x, 2*i + 1) / Utils.CalculateBigDecimalFactorial(2*i + 1);
                if (BigDecimal.Abs(possibleRemainder) < BigDecimal.PowBig(10, wantedRemainder))
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
            BigDecimal result = 1;
            for (int i = 1; i <= remainderResult.RemainderOrder; ++i)
            {
                BigDecimal ithElement = BigDecimal.PowBig(-1, i) * BigDecimal.PowBig(x, 2*i) /
                                        Utils.CalculateBigDecimalFactorial(2*i);

                result += ithElement;
            }
            return result;
        }
    }
}
