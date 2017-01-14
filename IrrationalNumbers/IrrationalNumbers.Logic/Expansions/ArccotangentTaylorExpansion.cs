
namespace IrrationalNumbers.Logic.Expansions
{
    public class ArccotangentTaylorExpansion : IBasicFunctionExpansion
    {
        public BigDecimal ExpandFunction(int wantedRemainder, BigDecimal x)
        {
            IBasicFunctionExpansion arctan = new ArctangentTaylorExpansion();
            IBasicFunctionExpansion pi = new PiTaylorExpansion();
            var tanExp = arctan.ExpandFunction(wantedRemainder, x).Truncate();
            var piExp = pi.ExpandFunction(wantedRemainder, 0).Truncate();
            var result = piExp / 2 - tanExp;
            return result;
        }
    }
}
