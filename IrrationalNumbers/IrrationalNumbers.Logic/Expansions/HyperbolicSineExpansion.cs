
namespace IrrationalNumbers.Logic.Expansions
{
    public class HyperbolicSineExpansion : IBasicFunctionExpansion
    {
        private readonly IBasicFunctionExpansion _exponentExpansion;

        public HyperbolicSineExpansion()
        {
            _exponentExpansion = new ExponentTaylorExpansion();
        }

        public BigDecimal ExpandFunction(int wantedRemainder, BigDecimal x)
        {
            x = x.Truncate();

            var upperPart = _exponentExpansion.ExpandFunction(wantedRemainder, x) -
                            _exponentExpansion.ExpandFunction(wantedRemainder, -x);

            return upperPart/(BigDecimal) 2.0;
        }
    }
}
