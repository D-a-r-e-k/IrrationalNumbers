
namespace IrrationalNumbers.Logic.Expansions
{
    public class HyperbolicTangentExpansion : IBasicFunctionExpansion
    {
        private readonly IBasicFunctionExpansion _exponentExpansion;

        public HyperbolicTangentExpansion()
        {
            _exponentExpansion = new ExponentTaylorExpansion();
        }

        public BigDecimal ExpandFunction(int wantedRemainder, double x)
        {
            var ex = _exponentExpansion.ExpandFunction(wantedRemainder, x);
            var minusEx = _exponentExpansion.ExpandFunction(wantedRemainder, -x);

            return (ex - minusEx) / (ex + minusEx);
        }
    }
}
