
using System;

namespace IrrationalNumbers.Logic.Expansions
{
    /// <summary>
    /// Apima visus case'us, kur f-ja yra tokios israiskos: (1+x)^a, kur x less than 1 ir a priklauso R.
    /// </summary>
    public class BinomicalMaclaurinExpansion: IBasicFunctionExpansion
    {
        private readonly double _alpha;
        private double _x;

        private readonly ParameterNormalizationResult _normalizationResult;

        public BinomicalMaclaurinExpansion(double alpha, double x)
        {
            _alpha = alpha;
            _x = x;

            _normalizationResult = Utils.NormalizeParameter(x, alpha);
        }

        private RemainderResult EvaluateN(BigDecimal normParameter, int wantedRemainder)
        {
            var c = (normParameter > 0 ? normParameter: 0) + 1;
            
            for (int i = 1; ; ++i)
            {
                var der = 1;
                //var der = (Utils.CalculateBigDecimalFactorial(new BigDecimal(_alpha), i)* BigDecimal.PowBig(c, _alpha - i));
                var derivative = der >= 0? der: der *-1;

                var xpow = BigDecimal.PowBig(normParameter, i + 1);
                var xPowerNth = xpow >= 0? xpow: xpow * -1;

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

            RemainderResult remainderResult = EvaluateN(_normalizationResult.NormalizedParameter, wantedRemainder);

            BigDecimal result = 1;
            for (int i = 1; i <= remainderResult.RemainderOrder; ++i)
            {
                BigDecimal ithCoeficientBig = BigDecimal.PowBig(_normalizationResult.NormalizedParameter, i) * Utils.CalculateBigDecimalFactorial(_alpha, i) / Utils.CalculateBigDecimalFactorial(i);
               // BigDecimal ithCoeficientBig = Utils.nCr(_alpha,i)
                result += ithCoeficientBig;
            }

            return _normalizationResult.FinalMultiplier * result;
        }


    }
}