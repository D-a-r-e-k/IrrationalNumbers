using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrrationalNumbers.Logic.Expansions
{
    public class ArccotangentTaylorExpansion : IBasicFunctionExpansion
    {
        public BigDecimal ExpandFunction(int wantedRemainder, double x)
        {
            IBasicFunctionExpansion arctan = new ArctangentTaylorExpansion();
            IBasicFunctionExpansion pi = new PiTaylorExpansion();
            var result = pi.ExpandFunction(wantedRemainder, 0) / 2 - arctan.ExpandFunction(wantedRemainder, x);
            return result;
        }
    }
}
