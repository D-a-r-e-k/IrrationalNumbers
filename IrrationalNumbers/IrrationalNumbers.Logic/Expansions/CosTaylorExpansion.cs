using System;

namespace IrrationalNumbers.Logic.Expansions
{
    public class CosTaylorExpansion : IBasicFunctionExpansion
    {
        public RemainderResult EvaluateN(int wantedRemainder, double x)
        {
            for (int i = 1; ; ++i)
            {
                //Skaičiuojamas liekamasis narys (i-asis laipsnis)
                double possibleRemainder = Math.Pow(x, 2*i + 1) / Utils.CalculateFactorial(2*i + 1);
                //Jei paklaida yra mažesnė už nurodytą laipsnį, grąžinama
                if (Math.Abs(possibleRemainder) < Math.Pow(10, wantedRemainder))
                    return new RemainderResult()
                    {
                        Remainder = possibleRemainder,
                        RemainderOrder = i
                    };
            }
        }

        public BigDecimal ExpandFunction(int wantedRemainder, double x)
        {
            //Kviečiama funkcija įvertinanti kokio laipsnio skleidinio mums reikia, grąžina eilę
            RemainderResult remainderResult = EvaluateN(wantedRemainder, x);
            //Skaičiuojama kosinuso reikšmė
            BigDecimal result = remainderResult.Remainder + 1;
            for (int i = 1; i <= remainderResult.RemainderOrder; ++i)
            {
                result += Math.Pow(-1, i)*Math.Pow(x, 2*i)/Utils.CalculateBigDecimalFactorial(2*i); // i-ojo laipsnio skleidinys
            }
            return result;
        }
    }
}
