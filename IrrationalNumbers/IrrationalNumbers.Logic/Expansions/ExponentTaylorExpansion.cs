using System;


namespace IrrationalNumbers.Logic.Expansions
{
    public class ExponentTaylorExpansion : IBasicFunctionExpansion
    {
        public RemainderResult EvaluateN(int wantedRemainder, double x)
        {
            double c = Math.Max(x, 0);

            for (int i = 1; ; ++i)
            {
                double possibleRemainder = Math.Pow(3, c) / Utils.CalculateFactorial(i + 1) * Math.Pow(x, i + 1);

                if (Math.Abs(possibleRemainder) < Math.Pow(10, wantedRemainder))
                    return new RemainderResult()
                    {
                        Remainder = possibleRemainder,
                        RemainderOrder = i
                    };
            }
        }

        public double ExpandFunction(int wantedRemainder, double x)
        {
            RemainderResult remainderResult = EvaluateN(wantedRemainder, x);

            double result = 1;
            for (int i = 1; i <= remainderResult.RemainderOrder; ++i)
                result += (Math.Pow(x, i) / Utils.CalculateFactorial(i));

            return result;
        }
    }
}
