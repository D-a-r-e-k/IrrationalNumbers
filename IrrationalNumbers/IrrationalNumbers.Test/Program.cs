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

            IBasicFunctionExpansion expansion = new NaturalLogarithmExpansion();

            int wantedRemainder = -2;
            double x = 2;

            var expectedAnswer = Math.Log(x, Math.E);
            var actualAnswer = expansion.ExpandFunction(wantedRemainder, x);

            Console.WriteLine(expectedAnswer);
            Console.WriteLine(actualAnswer);

            Console.ReadKey();
        }
    }
}
