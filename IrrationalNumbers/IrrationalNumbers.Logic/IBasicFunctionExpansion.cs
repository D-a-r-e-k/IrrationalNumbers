using IrrationalNumbers.Core;

namespace IrrationalNumbers.Logic
{
    public interface IBasicFunctionExpansion
    {
        BigDecimal ExpandFunction(int wantedRemainder, double x);
    }
}
