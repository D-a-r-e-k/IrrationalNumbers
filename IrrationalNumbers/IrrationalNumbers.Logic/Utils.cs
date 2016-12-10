using IrrationalNumbers.Core;

namespace IrrationalNumbers.Logic
{
    public static class Utils
    {
        public static BigFloat CalculateFactorial(int n)
        {
            BigFloat result = 1;
            for (int i = 1; i <= n; ++i)
                result *= i;
            return result;
        }
    }
}
