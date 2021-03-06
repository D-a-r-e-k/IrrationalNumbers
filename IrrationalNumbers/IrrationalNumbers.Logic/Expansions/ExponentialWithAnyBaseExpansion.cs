﻿using System;
using System.Threading.Tasks;

namespace IrrationalNumbers.Logic.Expansions
{
    public class ExponentialWithAnyBaseExpansion : IBasicFunctionExpansion
    {
        private static IBasicFunctionExpansion _naturalLogarithmExpansion;
        private BigDecimal _exponentBase;

        public void SetBase(BigDecimal exponentBase)
        {
            _exponentBase = exponentBase;
        }

        public ExponentialWithAnyBaseExpansion(BigDecimal exponentBase)
        {
            if (_naturalLogarithmExpansion == null)
                _naturalLogarithmExpansion = new NaturalLogarithmExpansion();
            _exponentBase = exponentBase;
        }

        public RemainderResult EvaluateN(int wantedRemainder, BigDecimal x, BigDecimal expandedLn)
        {
            BigDecimal calculatedWantedRemainder = BigDecimal.PowBig(10, wantedRemainder);

            int lo = 1;
            int hi = 10000;

            while (lo < hi)
            {
                int mid = (lo + hi) / 2;

                BigDecimal candidate = BigDecimal.PowBig(x, mid) * BigDecimal.PowBig(expandedLn, mid) / Utils.CalculateBigDecimalFactorial(mid);
                if (candidate < calculatedWantedRemainder)
                    hi = mid;
                else
                    lo = mid + 1;
            }

            if (BigDecimal.PowBig(x, hi) * BigDecimal.PowBig(expandedLn, hi) / Utils.CalculateBigDecimalFactorial(hi) < calculatedWantedRemainder)
                return new RemainderResult()
                {
                    Remainder = BigDecimal.PowBig(x, hi) * BigDecimal.PowBig(expandedLn, hi) / Utils.CalculateBigDecimalFactorial(hi),
                    RemainderOrder = hi
                };

            throw new Exception("Unsupported precision was provided.");
        }

        public BigDecimal ExpandFunction(int wantedRemainder, BigDecimal x)
        {
            x = x.Truncate();

            BigDecimal minus = 1;
            if (_exponentBase < 0)
            {
                minus = Math.Pow(-1, (double) x);

                _exponentBase = BigDecimal.Abs(_exponentBase);
            }

            BigDecimal expandedLn = _naturalLogarithmExpansion.ExpandFunction(wantedRemainder * 2, _exponentBase);
            RemainderResult remainderResult = EvaluateN(wantedRemainder, x, expandedLn);
           
            BigDecimal [] preCalculation = new BigDecimal[remainderResult.RemainderOrder + 1];
            Parallel.For(1, remainderResult.RemainderOrder + 1, i =>
            {
                preCalculation[i] = BigDecimal.PowBig(x, i) * BigDecimal.PowBig(expandedLn, i) /
                            Utils.CalculateBigDecimalFactorial(i);
            });

            BigDecimal result = 1;
            for (int i = 1; i <= remainderResult.RemainderOrder; ++i)
                result += preCalculation[i];

            return result*minus;
        }
    }
}
