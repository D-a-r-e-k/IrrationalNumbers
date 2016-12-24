
namespace IrrationalNumbers.Logic.Expansions
{
    public class HyperbolicCosineExpansion : IBasicFunctionExpansion
    {
        private readonly IBasicFunctionExpansion _exponentExpansion;

        public HyperbolicCosineExpansion()
        {
            _exponentExpansion = new ExponentTaylorExpansion();
        }

        public BigDecimal ExpandFunction(int wantedRemainder, double x)
        {
            var upperPart = _exponentExpansion.ExpandFunction(wantedRemainder, x) + 
                            _exponentExpansion.ExpandFunction(wantedRemainder, -x);

            return upperPart/(BigDecimal) 2.0;
        }
    }
}
