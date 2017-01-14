
using System;

namespace IrrationalNumbers.Logic.Expansions
{
    public class ArccosineTaylorExpansion : IBasicFunctionExpansion
    {
        private readonly PiTaylorExpansion _piTaylorExpansion;
        private readonly ArcsineTaylorExpansion _arcsineTaylorExpansion;

        public ArccosineTaylorExpansion()
        {
            _arcsineTaylorExpansion = new ArcsineTaylorExpansion();
            _piTaylorExpansion = new PiTaylorExpansion();
        }

        public BigDecimal ExpandFunction(int wantedRemainder, BigDecimal x)
        {
            var pi = _piTaylorExpansion.ExpandFunction(wantedRemainder - 1, 0) / 2.0;

            if (BigDecimal.Abs(x) < 1)
            {
                return pi - _arcsineTaylorExpansion.ExpandFunction(wantedRemainder - 1, x);
            }
            else
            {
                if (x == 1)               
                    return 0;             
                else if(x == -1)
                    return pi * 2;

                return 0;
            }
            /*BigDecimal result;
            ArctangentTaylorExpansion arctan = new ArctangentTaylorExpansion();

            result = sine.ExpandFunction(wantedRemainder, x) / cosine.ExpandFunction(wantedRemainder, x);
            return result;*/
        }
    }
}
