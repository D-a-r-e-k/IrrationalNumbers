
namespace IrrationalNumbers.Logic.Expansions
{
    public class ArccotangentTaylorExpansion : IBasicFunctionExpansion
    {
        public BigDecimal ExpandFunction(int wantedRemainder, BigDecimal x)
        {
            IBasicFunctionExpansion arctan = new ArctangentTaylorExpansion();
            IBasicFunctionExpansion pi = new PiTaylorExpansion();
            var result = pi.ExpandFunction(wantedRemainder, 0) / 2 - arctan.ExpandFunction(wantedRemainder, x);
            return result;
        }
    }
}
