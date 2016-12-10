using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathos.Parser;

namespace IrrationalNumbers.Test
{
    class Program
    {
        private static void Main(string[] args)
        {
            var parser = new MathParser();

            parser.LocalFunctions.Add("CustomFn", decimals => decimals[0] + 1);
            parser.LocalFunctions.Add("Custom", decimals => decimals[0] + 1);
            parser.LocalFunctions.Add("SuperCustom", decimals => decimals[0] + 1);

            parser.LocalFunctions["sin"] = decimals => 1;

            var result = parser.Parse("sin(1)");

            var result2 = parser.Parse("CustomFn(Custom(SuperCustom(1)))");

            Console.WriteLine("Result 1 is: " + result);
            Console.WriteLine("Result 2 is: " + result2);
            
        }
    }
}
