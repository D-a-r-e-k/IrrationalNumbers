using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrrationalNumbers.Logic.Expansions
{
    public class PiTaylorExpansion : IBasicFunctionExpansion
    {
        public RemainderResult EvaluateN(int wantedRemainder)
        {
            for (int i = 1; ; ++i)
            {
                BigDecimal possibleRemainder = BigDecimal.PowBig(-1, i + 1) / Utils.CalculateBigDecimalFactorial(2 * i - 1);
                if (BigDecimal.Abs(possibleRemainder) < BigDecimal.PowBig(10, wantedRemainder))
                    return new RemainderResult()
                    {
                        Remainder = possibleRemainder,
                        RemainderOrder = i
                    };
            }
        }

        public BigDecimal ExpandFunction(int wantedRemainder, double x = 0)
        {
            ArctangentTaylorExpansion tangent = new ArctangentTaylorExpansion();
            return 20*tangent.ExpandFunction(-20, 1.0/7) + 8*tangent.ExpandFunction(-20, 3.0/79);
            /*RemainderResult remainderResult = EvaluateN(wantedRemainder);
            //BigDecimal result = 0;
            for (int i = 1; i <= remainderResult.RemainderOrder; ++i)
            {
                var ithElement = BigDecimal.PowBig(-1, i + 1) /
                                        Utils.CalculateBigDecimalFactorial(2 * i - 1);

                result += ithElement;
            }
            return result * 4;*/
        }
    }
}
