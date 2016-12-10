using IrrationalNumbers.Logic;
using IrrationalNumbers.Logic.Expansions;
using System;

namespace IrrationalNumbers.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            IBasicFunctionExpansion expansion = new ExponentTaylorExpansion();

            Console.WriteLine(Math.Exp(2));
            Console.WriteLine(Math.Abs(expansion.ExpandFunction(-100, 2) - Math.Exp(2)));

            Console.ReadKey();
        }
    }
}
