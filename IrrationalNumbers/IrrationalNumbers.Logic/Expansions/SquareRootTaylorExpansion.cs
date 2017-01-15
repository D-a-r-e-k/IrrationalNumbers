
namespace IrrationalNumbers.Logic.Expansions
{
    /// <summary>
    /// Covers cases when function f is in the form: (1+x)^a where x less than 1 and a belongs to R.
    /// </summary>
    public class BinomicalMaclaurinExpansion: IBasicFunctionExpansion
    {
        private readonly bool _isNegativeAlpha = false;
        private readonly BigDecimal _alpha;

        private ParameterNormalizationResult _normalizationResult;

        public BinomicalMaclaurinExpansion(BigDecimal alpha)
        {
            if (alpha < 0)
            {
                _isNegativeAlpha = true;
                alpha = BigDecimal.Abs(alpha);
            }

            _alpha = alpha;
        }

        public BigDecimal ExpandFunction(int wantedRemainder, BigDecimal x)
        {
            _normalizationResult = Utils.NormalizeParameter(x, _alpha, wantedRemainder);

            BigDecimal result = 1;
            var remainder = BigDecimal.PowBig(10, wantedRemainder);
            for (int i = 1; ; ++i)
            {
                var ith = BigDecimal.PowBig(_normalizationResult.NormalizedParameter, i) * Utils.CalculateBigDecimalFactorial(_alpha, i) / Utils.CalculateBigDecimalFactorial(i);
                BigDecimal ithCoeficientBig = BigDecimal.Abs(ith);

                if (ithCoeficientBig <= remainder)
                {
                    break;
                }
                result += ith;

                if (i % 40 == 0)
                    result = result.Truncate();
            }

            if (_isNegativeAlpha)
                return 1 / _normalizationResult.FinalMultiplier * result;

            return _normalizationResult.FinalMultiplier* result;
        }
    }
}