using System;

namespace IrrationalNumbers.Logic.Expansions
{
    public class NaturalLogarithmExpansion : IBasicFunctionExpansion
    {

        public RemainderResult EvaluateN(int wantedRemainder, double x)
        {
            //double c = Math.Max(x, 0);

            for (int i = 1; ; ++i)
            {
                if (1 / ((double) (i + 1)) < Math.Pow(10, wantedRemainder))
                    return new RemainderResult()
                    {
                        Remainder = 1 / (i + 1),
                        RemainderOrder = i
                    };
            }
        }

        public BigDecimal ExpandFunction(int wantedRemainder, double x)
        {
            //ParameterNormalizationResult xNormalized = Utils.NormalizeParameter(x);
            RemainderResult remainderResult = EvaluateN(wantedRemainder, x);

            BigDecimal result = x;
            for (int i = 1; i <= remainderResult.RemainderOrder; ++i)
            {
                BigDecimal ithCoeficientBig = BigDecimal.PowBig(-1, i) * BigDecimal.PowBig(x, i + 1)/ (BigDecimal)(i + 1);
                result += ithCoeficientBig;
            }

            return (BigDecimal)  result;
        }
    }
}
