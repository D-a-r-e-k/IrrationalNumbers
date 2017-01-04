
using System;

namespace IrrationalNumbers.Logic.Expansions
{
    /// <summary>
    /// Apima visus case'us, kur f-ja yra tokios israiskos: (1+x)^a, kur x less than 1 ir a priklauso R.
    /// </summary>
    public class BinomicalMaclaurinExpansion: IBasicFunctionExpansion
    {
        private readonly double _alpha;

        private IBasicFunctionExpansion expansion;


        private readonly ParameterNormalizationResult _normalizationResult;

        public BinomicalMaclaurinExpansion(double alpha, double x)
        {
            _alpha = alpha;
            _normalizationResult = Utils.NormalizeParameter(x, alpha);
        }

        private RemainderResult EvaluateN(BigDecimal normParameter, int wantedRemainder)
        {
           // var c = (normParameter > 0 ? normParameter: 0) + 1;
            var c = normParameter  + 1;

            var exponentExpansion = new ExponentialWithAnyBaseExpansion(c);

            for (int i = 1; ; ++i)
            {
               // var powRational = Math.Pow(c, _alpha - i);
                var powRational = exponentExpansion.ExpandFunction(wantedRemainder, _alpha - i);

                var der = (Utils.CalculateBigDecimalFactorial(new BigDecimal(_alpha), i)* powRational);
                var derivative = der >= 0? der: der *-1;

                var xpow = BigDecimal.PowBig(normParameter, i + 1);
                var xPowerNth = xpow >= 0 ? xpow : xpow * -1;

                var inequalityRightSide = Utils.CalculateBigDecimalFactorial(i + 1) * BigDecimal.PowBig(10, wantedRemainder);

                if (derivative * xPowerNth < inequalityRightSide)
                    return new RemainderResult()
                    {
                        RemainderOrder = i
                    };
            }
        }


        public BigDecimal ExpandFunction(int wantedRemainder, double x)
        {
            BigDecimal result = 1;
            var remainder = BigDecimal.PowBig(10, wantedRemainder);
            for (int i = 1;; ++i)
            {
                var ith = BigDecimal.PowBig(_normalizationResult.NormalizedParameter, i) * Utils.CalculateBigDecimalFactorial(_alpha, i) / Utils.CalculateBigDecimalFactorial(i);
                BigDecimal ithCoeficientBig = BigDecimal.Abs(ith);

                if (ithCoeficientBig <= remainder)
                {
                    break;
                }
                result += ith;

                if (i%40 == 0)
                    result = result.Truncate();
            }

            return _normalizationResult.FinalMultiplier * result;
        }


    }
}