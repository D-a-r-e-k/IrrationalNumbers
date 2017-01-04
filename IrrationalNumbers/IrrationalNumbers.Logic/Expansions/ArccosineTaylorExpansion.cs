using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrrationalNumbers.Logic.Expansions
{
    public class ArccosineTaylorExpansion : IBasicFunctionExpansion
    {
        public BigDecimal ExpandFunction(int wantedRemainder, double x)
        {
            throw new NotImplementedException();
            /*BigDecimal result;
            ArctangentTaylorExpansion arctan = new ArctangentTaylorExpansion();

            result = sine.ExpandFunction(wantedRemainder, x) / cosine.ExpandFunction(wantedRemainder, x);
            return result;*/
        }
    }
}
