using System;
using System.Threading.Tasks;

namespace IrrationalNumbers.Logic.Expansions
{
    public class ExponentialWithAnyBaseExpansion : IBasicFunctionExpansion
    {
        private readonly IBasicFunctionExpansion _naturalLogarithmExpansion;
        private readonly double _exponentBase;

        public ExponentialWithAnyBaseExpansion(double exponentBase)
        {
            _naturalLogarithmExpansion = new NaturalLogarithmExpansion();
            _exponentBase = exponentBase;
        }

        public RemainderResult EvaluateN(int wantedRemainder, BigDecimal x)
        {
            BigDecimal expandedLn = _naturalLogarithmExpansion.ExpandFunction(wantedRemainder * 2, (double)_exponentBase);

            for (int i = 1; ; ++i)
            {
                if (BigDecimal.PowBig(x, i) * BigDecimal.PowBig(expandedLn, i) 
                     < Math.Pow(10, wantedRemainder) * Utils.CalculateBigDecimalFactorial(i))
                    return new RemainderResult()
                    {
                        Remainder = BigDecimal.PowBig(x, i) * BigDecimal.PowBig(expandedLn, i) / 
                            Utils.CalculateBigDecimalFactorial(i),
                        RemainderOrder = i
                    };
            }
        }

        public BigDecimal ExpandFunction(int wantedRemainder, double x)
        {
            RemainderResult remainderResult = EvaluateN(wantedRemainder, x);

            BigDecimal expandedLn = _naturalLogarithmExpansion.ExpandFunction(wantedRemainder * 2, (double)_exponentBase);

            BigDecimal [] preCalculation = new BigDecimal[remainderResult.RemainderOrder + 1];
            Parallel.For(1, remainderResult.RemainderOrder + 1, i =>
            {
                preCalculation[i] = BigDecimal.PowBig(x, i) * BigDecimal.PowBig(expandedLn, i) /
                            Utils.CalculateBigDecimalFactorial(i);
            });

            BigDecimal result = 1;
            for (int i = 1; i <= remainderResult.RemainderOrder; ++i)
                result += preCalculation[i];

            return result;
        }
    }
}
