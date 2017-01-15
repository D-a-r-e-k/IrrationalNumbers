
namespace IrrationalNumbers.Logic.Expansions
{
    public class ArccotangentTaylorExpansion : IBasicFunctionExpansion
    {
        public BigDecimal ExpandFunction(int wantedRemainder, BigDecimal x)
        {
            x = x.Truncate();

            IBasicFunctionExpansion arctan = new ArctangentTaylorExpansion();

            return arctan.ExpandFunction(wantedRemainder, ((BigDecimal) 1)/x);
        }
    }
}
