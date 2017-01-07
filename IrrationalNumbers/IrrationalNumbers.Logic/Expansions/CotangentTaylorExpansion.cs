
namespace IrrationalNumbers.Logic.Expansions
{
    public class CotangentTaylorExpansion : IBasicFunctionExpansion
    {
        public BigDecimal ExpandFunction(int wantedRemainder, BigDecimal x)
        {
            SineTaylorExpansion sine = new SineTaylorExpansion();
            CosineTaylorExpansion cosine = new CosineTaylorExpansion();

            var result = cosine.ExpandFunction(wantedRemainder - 1, x) / sine.ExpandFunction(wantedRemainder - 1, x);

            return result;
        }
    }
}
