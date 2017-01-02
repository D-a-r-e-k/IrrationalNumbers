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
            BigDecimal result;
            SineTaylorExpansion sine = new SineTaylorExpansion();
            CosineTaylorExpansion cosine = new CosineTaylorExpansion();

            result = sine.ExpandFunction(wantedRemainder, x)/cosine.ExpandFunction(wantedRemainder, x);
            return result;
        }
    }
}
