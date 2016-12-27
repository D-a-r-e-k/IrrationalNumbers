
using System;

namespace IrrationalNumbers.Logic.Expansions
{
    /// <summary>
    /// Apima visus case'us, kur f-ja yra tokios israiskos: (1+x)^a, kur x less than 1 ir a priklauso R.
    /// </summary>
    public class BinomicalMaclaurinExpansion: IBasicFunctionExpansion
    {
        private float _alpha;
        private float _x;

        private ParameterNormalizationResult _normalizationResult;

        public BinomicalMaclaurinExpansion(float alpha, float x)
        {
            _alpha = alpha;
            _x = x;

            _normalizationResult = Utils.NormalizeParameter(x);
        }

        private RemainderResult EvaluateN(float normParameter, int wantedRemainder)
        {
            double c = 1 + normParameter;

            for (int i = 1; ; ++i)
            {
                if (Math.Pow(c, _alpha - i + 1) * Math.Pow(normParameter, i + 1) * Utils.CalculateFactorial(_alpha, i + 1) < Utils.CalculateFactorial(i + 1) * Math.Pow(10, wantedRemainder))
                    return new RemainderResult()
                    {
                        Remainder = Math.Pow(c, _alpha - i + 1) * Math.Pow(normParameter, i + 1) * Utils.CalculateFactorial(_alpha, i + 1) / Utils.CalculateFactorial(_alpha, i + 1),
                        RemainderOrder = i
                    };
            }
        }


        public BigDecimal ExpandFunction(int wantedRemainder, double x)
        {
            RemainderResult remainderResult = EvaluateN(wantedRemainder,(int) x);

            BigDecimal result = 1;
            for (int i = 1; i <= remainderResult.RemainderOrder; ++i)
            {
                BigDecimal ithCoeficientBig = BigDecimal.PowBig(x, i) * Utils.CalculateFactorial(_alpha, i) / Utils.CalculateBigDecimalFactorial(i);
                result += ithCoeficientBig;
            }

            return result;
        }


    }
}