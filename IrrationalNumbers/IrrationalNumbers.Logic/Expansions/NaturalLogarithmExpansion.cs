using System;

namespace IrrationalNumbers.Logic.Expansions
{
    public class NaturalLogarithmExpansion : IBasicFunctionExpansion
    {
        private IBasicFunctionExpansion _exponentExpansion;

        public NaturalLogarithmExpansion()
        {
            _exponentExpansion = new ExponentTaylorExpansion();
        }

        public RemainderResult EvaluateN(int wantedRemainder, BigDecimal x)
        {
            for (int i = 1; ; ++i)
            {
                if (BigDecimal.Abs(BigDecimal.PowBig(x, i) / (BigDecimal)i) < BigDecimal.PowBig(10, wantedRemainder))
                    return new RemainderResult()
                    {
                        Remainder = BigDecimal.Abs(BigDecimal.PowBig(x, i) / (BigDecimal)i),
                        RemainderOrder = i
                    };
            }
        }

        public BigDecimal ExpandFunction(int wantedRemainder, double x)
        {
            var transformedX = TransformParameter(x, wantedRemainder);

            RemainderResult remainderResult = EvaluateN(wantedRemainder, transformedX.Remainder);

            BigDecimal result = transformedX.Remainder;
            for (int i = 1; i <= remainderResult.RemainderOrder; ++i)
            {
                BigDecimal ithCoeficientBig = BigDecimal.PowBig(-1, i) * BigDecimal.PowBig(transformedX.Remainder, i + 1)/ (BigDecimal)(i + 1);
                result += ithCoeficientBig;
            }

            return (BigDecimal) transformedX.RemainderOrder + result;
        }

        private RemainderResult TransformParameter(BigDecimal x, int wantedRemainder)
        {
            BigDecimal expandedE = _exponentExpansion.ExpandFunction(wantedRemainder, 1);

            int d = 1;
            while (BigDecimal.PowBig(expandedE, d) < x) d++;

            return new RemainderResult()
            {
                Remainder = x / BigDecimal.PowBig(expandedE, d) - 1,
                RemainderOrder = d
            };
        }
    }
}
