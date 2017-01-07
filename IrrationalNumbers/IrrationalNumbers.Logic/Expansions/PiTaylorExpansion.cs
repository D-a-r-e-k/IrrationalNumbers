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

        public BigDecimal ExpandFunction(int wantedRemainder, BigDecimal x)
        {
            var tangent = new ArctangentTaylorExpansion();

            return 20*tangent.ExpandFunction(wantedRemainder-1, (BigDecimal)1.0 / (BigDecimal)7) + 8*tangent.ExpandFunction(wantedRemainder-1, (BigDecimal)3.0/(BigDecimal)79);
        }
    }
}
