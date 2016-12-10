using System;
using IrrationalNumbers.Core;

namespace IrrationalNumbers.Logic
{
    public class CosTaylorExpansion 
    {

        //public RemainderResult EvaluateN(int wantedRemainder, double x)
        //{
        //    for (int i = 1; ; ++i)
        //    {
        //        double possibleRemainder = Math.Pow(x, 2*i + 1) / Utils.CalculateFactorial(2*i + 1);

        //        if (Math.Abs(possibleRemainder) < Math.Pow(10, wantedRemainder))
        //            return new RemainderResult()
        //            {
        //                Remainder = possibleRemainder,
        //                RemainderOrder = i
        //            };
        //    }
        //}

        //public double ExpandFunction(int wantedRemainder, double x)
        //{
        //    RemainderResult remainderResult = EvaluateN(wantedRemainder, x);

        //    double result = remainderResult.Remainder + 1;
        //    for (int i = 1; i <= remainderResult.RemainderOrder; ++i)
        //        result += Math.Pow(-1, i)*Math.Pow(x, 2*i)/Utils.CalculateFactorial(2*i);

        //    return result;
        //}
    }
}
