
using System;

namespace IrrationalNumbers.Logic.Expansions
{
    public class LogarithmExpansion : IBasicFunctionExpansion
    {
        private readonly IBasicFunctionExpansion _naturalLogarithmExpansion;
        private readonly BigDecimal _logarithmBase;

        public LogarithmExpansion(BigDecimal logarithmBase)
        {
            _naturalLogarithmExpansion = new NaturalLogarithmExpansion();
            _logarithmBase = logarithmBase;
        }

        public BigDecimal ExpandFunction(int wantedRemainder, BigDecimal x)
        {
            x = x.Truncate();

            if (BigDecimal.Abs(x - 1) < Math.Pow(10, wantedRemainder))
                return 0;

            var upperPart = _naturalLogarithmExpansion.ExpandFunction(wantedRemainder, x);
            var bottomPart = _naturalLogarithmExpansion.ExpandFunction(wantedRemainder, _logarithmBase);

            return upperPart/bottomPart;
        }
    }
}
