using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrrationalNumbers.Logic.Expansions
{
    public class CotangentTaylorExpansion : IBasicFunctionExpansion
    {
        public BigDecimal ExpandFunction(int wantedRemainder, double x)
        {
            BigDecimal result;
            SineTaylorExpansion sine = new SineTaylorExpansion();
            CosineTaylorExpansion cosine = new CosineTaylorExpansion();

            result = cosine.ExpandFunction(wantedRemainder, x) / sine.ExpandFunction(wantedRemainder, x);
            return result;
        }
    }
}
