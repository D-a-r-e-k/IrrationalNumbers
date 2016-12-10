using IrrationalNumbers.Core;

namespace IrrationalNumbers.Logic
{
    public interface IBasicFunctionExpansion
    {
        BigFloat ExpandFunction(int wantedRemainder, double x);
    }
}
