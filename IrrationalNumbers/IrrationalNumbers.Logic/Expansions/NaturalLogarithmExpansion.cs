using System;
using System.Threading.Tasks;

namespace IrrationalNumbers.Logic.Expansions
{
    public class NaturalLogarithmExpansion : IBasicFunctionExpansion
    {
        private readonly IBasicFunctionExpansion _exponentExpansion;

        public NaturalLogarithmExpansion()
        {
            _exponentExpansion = new ExponentTaylorExpansion();
        }

        public RemainderResult EvaluateN(int wantedRemainder, BigDecimal x)
        {
            BigDecimal calculatedWantedRemainder = BigDecimal.PowBig(10, wantedRemainder);

            int lo = 1;
            int hi = 1000;

            while (lo < hi)
            {
                int mid = (lo + hi)/2;

                BigDecimal candidate = BigDecimal.Abs(BigDecimal.PowBig(x, mid) / (BigDecimal) mid);
                if (candidate < calculatedWantedRemainder)
                    hi = mid;
                else
                    lo = mid + 1;
            }

            if (BigDecimal.Abs(BigDecimal.PowBig(x, hi) / (BigDecimal)hi) < calculatedWantedRemainder)
                return new RemainderResult()
                {
                    Remainder = BigDecimal.Abs(BigDecimal.PowBig(x, hi) / (BigDecimal)hi),
                    RemainderOrder = hi
                };
            
            throw new Exception("Unsupported precision was provided.");
        }

        public BigDecimal ExpandFunction(int wantedRemainder, BigDecimal x)
        {
            x = x.Truncate();

            var transformedX = TransformParameter(x, wantedRemainder);

            RemainderResult remainderResult = EvaluateN(wantedRemainder, transformedX.Remainder);

            BigDecimal result = transformedX.Remainder;
            BigDecimal [] resultParts = new BigDecimal[remainderResult.RemainderOrder + 1];
            Parallel.For(1, remainderResult.RemainderOrder + 1, i =>
            {
                resultParts[i] = BigDecimal.PowBig(-1, i) * BigDecimal.PowBig(transformedX.Remainder, i + 1) / (BigDecimal)(i + 1);
            });

            for (int i = 1; i <= remainderResult.RemainderOrder; ++i)
                result += resultParts[i];

            return (BigDecimal) transformedX.RemainderOrder + result;
        }

        private RemainderResult TransformParameter(BigDecimal x, int wantedRemainder)
        {
            BigDecimal expandedE = _exponentExpansion.ExpandFunction(wantedRemainder, 1);

            int d = 1;
            while (BigDecimal.PowBig(expandedE, d) < x) d++;

            return new RemainderResult()
            {
                Remainder = x / BigDecimal.PowBig(expandedE, d) - 1,
                RemainderOrder = d
            };
        }
    }
}
