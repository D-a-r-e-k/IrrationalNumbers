using IrrationalNumbers.Core;

namespace IrrationalNumbers.Logic
{
    public static class Utils
    {
        public static BigDecimal CalculateFactorial(int n)
        {
            BigDecimal result = 1;
            for (int i = 1; i <= n; ++i)
                result *= i;
            return result;
        }
    }
}
