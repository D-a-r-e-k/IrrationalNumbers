using IrrationalNumbers.Logic;
using IrrationalNumbers.Logic.Expansions;
using System;

using Mathos.Parser;

namespace IrrationalNumbers.Test
{
    class Program
    {
        private static void Main(string[] args)
        {
            //var parser = new MathParser();

            //parser.LocalFunctions.Add("CustomFn", decimals => decimals[0] + 1);
            //parser.LocalFunctions.Add("Custom", decimals => decimals[0] + 1);
            //parser.LocalFunctions.Add("SuperCustom", decimals => decimals[0] + 1);

            //parser.LocalFunctions["sin"] = decimals => 1;

            //var result = parser.Parse("sin(1)");

            //var result2 = parser.Parse("CustomFn(Custom(SuperCustom(1)))");

            //Console.WriteLine("Result 1 is: " + result);
            //Console.WriteLine("Result 2 is: " + result2);

            IBasicFunctionExpansion expansion = new ExponentialWithAnyBaseExpansion(8);

            int wantedRemainder = -6;
            double x = 4;

            var expectedAnswer = Math.Pow(8, x);
            var actualAnswer = expansion.ExpandFunction(wantedRemainder, x);

            Console.WriteLine(expectedAnswer);
            Console.WriteLine(actualAnswer);

            double a = 8;

            double result = 1;
            for (int i = 0; i < 33; ++i)
                result += Math.Pow(x, i + 1)*Math.Pow(Math.Log(a, Math.E), i + 1)/Utils.CalculateFactorial(i + 1);
            //Console.WriteLine(1 + x * Math.Log(a, Math.E) + x*x*Math.Log(a, Math.E) *Math.Log(a, Math.E) / 2.0 + x*x*x*Math.Log(a, Math.E)*Math.Log(a, Math.E) *Math.Log(a, Math.E)/ 6.0);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
