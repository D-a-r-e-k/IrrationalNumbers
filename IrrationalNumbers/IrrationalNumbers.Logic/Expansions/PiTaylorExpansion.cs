

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
            return 20*tangent.ExpandFunction(wantedRemainder+1, 1.0/7) + 8*tangent.ExpandFunction(wantedRemainder+1, 3.0/79);
            //return 176 * tangent.ExpandFunction(wantedRemainder+1, 74684.0 / 14967113) + 556 * tangent.ExpandFunction(wantedRemainder + 1, 1.0 / 239) - 48 * tangent.ExpandFunction(wantedRemainder + 1, 20138.0/15351991);
        }
    }
}
