
using System;

namespace IrrationalNumbers.Logic.Expansions
{
    public class LogarithmExpansion : IBasicFunctionExpansion
    {
        private readonly IBasicFunctionExpansion _naturalLogarithmExpansion;
        private readonly double _logarithmBase;

        public LogarithmExpansion(double logarithmBase)
        {
            _naturalLogarithmExpansion = new NaturalLogarithmExpansion();
            _logarithmBase = logarithmBase;
        }

        public BigDecimal ExpandFunction(int wantedRemainder, double x)
        {
            if (Math.Abs(x - 1) < Math.Pow(10, wantedRemainder))
                return 0;

            var upperPart = _naturalLogarithmExpansion.ExpandFunction(wantedRemainder, x);
            var bottomPart = _naturalLogarithmExpansion.ExpandFunction(wantedRemainder, _logarithmBase);

            return upperPart/bottomPart;
        }
    }
}
