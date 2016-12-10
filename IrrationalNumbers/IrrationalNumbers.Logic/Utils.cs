

namespace IrrationalNumbers.Logic
{
    public static class Utils
    {
        public static double CalculateFactorial(int n)
        {
            double result = 1;
            for (int i = 1; i <= n; ++i)
                result *= i;
            return result;
        }
    }
}
