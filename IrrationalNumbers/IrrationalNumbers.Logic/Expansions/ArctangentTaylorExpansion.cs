using System;

namespace IrrationalNumbers.Logic.Expansions
{
    public class ArctangentTaylorExpansion : IBasicFunctionExpansion
    {
        public RemainderResult EvaluateN(int wantedRemainder, BigDecimal x)
        {
            if (BigDecimal.Abs(x) < 1)
            {
                for (int i = 1;; ++i)
                {
                    BigDecimal possibleRemainder = BigDecimal.PowBig(x, 2*i - 1)*BigDecimal.PowBig(-1, i + 1)/(2*i - 1);
                    if (BigDecimal.Abs(possibleRemainder) < BigDecimal.PowBig(10, wantedRemainder))
                        return new RemainderResult()
                        {
                            Remainder = possibleRemainder,
                            RemainderOrder = i
                        };
                }
            }
            if (BigDecimal.Abs(x) > 1)
            {
                for (int i = 0;; ++i)
                {
                    BigDecimal possibleRemainder = BigDecimal.PowBig(x, -2*i - 1)*BigDecimal.PowBig(-1, i)/(2*i + 1);
                    if (BigDecimal.Abs(possibleRemainder) < BigDecimal.PowBig(10, wantedRemainder))
                        return new RemainderResult()
                        {
                            Remainder = possibleRemainder,
                            RemainderOrder = i
                        };
                }
            }
            return null;
        }

        public BigDecimal ExpandFunction(int wantedRemainder, BigDecimal x)
        {           
            RemainderResult remainderResult = EvaluateN(wantedRemainder, x);
            BigDecimal result = new BigDecimal(0);
            IBasicFunctionExpansion pi_expansion = new PiTaylorExpansion();

            if (BigDecimal.Abs(x) < 1)
                for (int i = 1; i <= remainderResult.RemainderOrder; ++i)
                {
                    var ithElement = BigDecimal.PowBig(-1, i+1) * BigDecimal.PowBig(x, 2 * i - 1) / (2 * i - 1);

                    result += ithElement;
                }
            else if (BigDecimal.Abs(x) > 1)
            {
                var pi = pi_expansion.ExpandFunction(wantedRemainder, 0);
                var minusPlus = 1;
                if (x < 0.0)
                {
                    minusPlus = -1;
                }
                var extra = pi*minusPlus/2;
                for (int i = 0; i<=remainderResult.RemainderOrder; ++i)
                {
                    BigDecimal possibleRemainder = BigDecimal.PowBig(x, -2 * i - 1) * BigDecimal.PowBig(-1, i) / (2 * i + 1);
                    result -= possibleRemainder;
                }
                result += extra;
            }
            else
            {
                var pi = pi_expansion.ExpandFunction(wantedRemainder, 0);
                result = pi/4;
            }
            return result;
        }
    }
}
