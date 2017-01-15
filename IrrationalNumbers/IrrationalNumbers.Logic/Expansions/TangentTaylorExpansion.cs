namespace IrrationalNumbers.Logic.Expansions
{
    public class TangentTaylorExpansion : IBasicFunctionExpansion
    {
        public BigDecimal ExpandFunction(int wantedRemainder, BigDecimal x)
        {
            x = x.Truncate();

            SineTaylorExpansion sine = new SineTaylorExpansion();
            CosineTaylorExpansion cosine = new CosineTaylorExpansion();

            var result = sine.ExpandFunction(wantedRemainder - 1, x)/cosine.ExpandFunction(wantedRemainder - 1, x);
            return result;
        }
    }
}
