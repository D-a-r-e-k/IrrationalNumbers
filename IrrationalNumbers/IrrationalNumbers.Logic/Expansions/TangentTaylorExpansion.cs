using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrrationalNumbers.Logic.Expansions
{
    public class TangentTaylorExpansion : IBasicFunctionExpansion
    {
        public BigDecimal ExpandFunction(int wantedRemainder, double x)
        {
            SineTaylorExpansion sine = new SineTaylorExpansion();
            CosineTaylorExpansion cosine = new CosineTaylorExpansion();

            var result = sine.ExpandFunction(wantedRemainder - 1, x)/cosine.ExpandFunction(wantedRemainder - 1, x);
            return result;
        }
    }
}
