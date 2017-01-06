using System;

namespace IrrationalNumbers.Logic.Expansions
{
    public class ArcsineTaylorExpansion : IBasicFunctionExpansion
    {
        private readonly IBasicFunctionExpansion _piExpansion;

        public ArcsineTaylorExpansion()
        {
            _piExpansion = new PiTaylorExpansion();
        }

        public RemainderResult EvaluateN(int wantedRemainder, double x)
        {
            for (int i = 1;; i++)
            {
                BigDecimal possibleRemainder = BigDecimal.PowBig(x, 2*i + 1);

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
            if (Math.Abs(x) < 1)
            {
                RemainderResult remainderResult = EvaluateN(wantedRemainder, x);

                BigDecimal result = x;

                BigDecimal upperPart = 1;
                BigDecimal bottomPart = 2;

                int upperPartJ = 1;
                int bottomPartJ = 2;

                for (int i = 1; i <= remainderResult.RemainderOrder; i++)
                {
                    BigDecimal ithElement = BigDecimal.PowBig(x, 2 * i + 1) * upperPart / (bottomPart * (2 * i + 1));

                    upperPartJ += 2;
                    bottomPartJ += 2;

                    upperPart *= upperPartJ;
                    bottomPart *= bottomPartJ;

                    result += ithElement;
                }

                return result;
            }
            else
            {
                if (x < 0)
                    return -_piExpansion.ExpandFunction(wantedRemainder, 0)/2.0;
                else
                    return _piExpansion.ExpandFunction(wantedRemainder, 0)/2.0;
            }
        }
    }
}
