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
            BigDecimal x1 = new BigDecimal(new BigInteger(200855259503435478344512630226915941201655487369773084059d),-55);
            var x2 = new BigDecimal(1, -4);
            BigDecimal s = 0.0000000000000000000000000000000000000000000000000012;
            BigDecimal d = 0.0000000000000000000000000000000000000000000000000013;
            Console.WriteLine(s < d);

            IBasicFunctionExpansion expansion = new ExponentTaylorExpansion();

            //Console.REa
            Console.WriteLine(expansion.ExpandFunction(-100,2) - Math.Exp(2));


            Console.ReadKey();
        }
    }
}
