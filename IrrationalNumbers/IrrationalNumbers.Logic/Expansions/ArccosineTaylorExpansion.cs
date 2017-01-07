
using System;

namespace IrrationalNumbers.Logic.Expansions
{
    public class ArccosineTaylorExpansion : IBasicFunctionExpansion
    {
        public BigDecimal ExpandFunction(int wantedRemainder, BigDecimal x)
        {
            throw new NotImplementedException();
            /*BigDecimal result;
            ArctangentTaylorExpansion arctan = new ArctangentTaylorExpansion();

            result = sine.ExpandFunction(wantedRemainder, x) / cosine.ExpandFunction(wantedRemainder, x);
            return result;*/
        }
    }
}
