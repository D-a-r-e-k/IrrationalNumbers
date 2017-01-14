
namespace IrrationalNumbers.Logic.Expansions
{
    public class ArccotangentTaylorExpansion : IBasicFunctionExpansion
    {
        public BigDecimal ExpandFunction(int wantedRemainder, BigDecimal x)
        {
            IBasicFunctionExpansion arctan = new ArctangentTaylorExpansion();

            return arctan.ExpandFunction(wantedRemainder, ((BigDecimal) 1)/x);
        }
    }
}
