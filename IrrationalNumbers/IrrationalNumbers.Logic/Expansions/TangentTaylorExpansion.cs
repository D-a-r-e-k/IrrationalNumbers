namespace IrrationalNumbers.Logic.Expansions
{
    public class TangentTaylorExpansion : IBasicFunctionExpansion
    {
        public BigDecimal ExpandFunction(int wantedRemainder, BigDecimal x)
        {
            SineTaylorExpansion sine = new SineTaylorExpansion();
            CosineTaylorExpansion cosine = new CosineTaylorExpansion();

            var result = sine.ExpandFunction(wantedRemainder - 1, x)/cosine.ExpandFunction(wantedRemainder - 1, x);
            return result;
        }
    }
}
