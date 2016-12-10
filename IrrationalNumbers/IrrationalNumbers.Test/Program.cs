using IrrationalNumbers.Logic;
using IrrationalNumbers.Logic.Expansions;
using System;
using System.Numerics;
using IrrationalNumbers.Core;
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
            BigFloat x1 = new BigFloat(new BigInteger(200855259503435478344512630226915941201655487369773084059d),-55);
            var x2 = new BigFloat(1, -4);
            BigFloat s = 0.0000000000000000000000000000000000000000000000000012;
            BigFloat d = 0.0000000000000000000000000000000000000000000000000013;
            Console.WriteLine(x1 < x2);

            IBasicFunctionExpansion expansion = new ExponentTaylorExpansion();

            //Console.REa
            Console.WriteLine(expansion.ExpandFunction(-100,2) - Math.Exp(2));


            Console.ReadKey();
        }
    }
}
