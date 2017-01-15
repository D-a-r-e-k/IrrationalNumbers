
namespace IrrationalNumbers.Logic.Expansions
{
    public class HyperbolicCotangentExpansion : IBasicFunctionExpansion
    {
        private readonly IBasicFunctionExpansion _exponentExpansion;

        public HyperbolicCotangentExpansion()
        {
            _exponentExpansion = new ExponentTaylorExpansion();
        }

        public BigDecimal ExpandFunction(int wantedRemainder, BigDecimal x)
        {
            x = x.Truncate();

            var ex = _exponentExpansion.ExpandFunction(wantedRemainder, x);
            var minusEx = _exponentExpansion.ExpandFunction(wantedRemainder, -x);

            return (ex + minusEx) / (ex - minusEx);
        }
    }
}
