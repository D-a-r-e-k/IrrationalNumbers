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

            IBasicFunctionExpansion expansion = new HyperbolicSineExpansion();
            Console.WriteLine(expansion.ExpandFunction(-4,2));
            Console.WriteLine(new CosTaylorExpansion().ExpandFunction(-3, 5));
            Console.ReadKey();
        }
    }
}
