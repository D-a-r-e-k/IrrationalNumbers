using IrrationalNumbers.Logic.Expansions;
using System;

using Mathos.Parser;

namespace IrrationalNumbers.Test
{
    class Program
    {
        private static void Main(string[] args)
        {
            do
            {
                Console.Write("Please type expression for estimation (exit - to exit the program): ");
                string expressionToBeEstimated = Console.ReadLine();

                if (expressionToBeEstimated == "exit")
                    break;

                if (string.IsNullOrEmpty(expressionToBeEstimated))
                {
                    Console.WriteLine("Type valid expression");
                    continue;
                }

                Console.Write("Please type acceptable error (in format 1 / 10^x where x should be provided): ");
                var remainder = Console.ReadLine();
                int remainderParsed;
                if (!int.TryParse(remainder, out remainderParsed))
                    Console.WriteLine("Acceptable error was provided not in correct format.");

                var parser = new MathParser();

                

                var result = parser.Parse("sin(1)");

                var result2 = parser.Parse("CustomFn(Custom(SuperCustom(1)))");

                Console.WriteLine("Result 1 is: " + result);
                Console.WriteLine("Result 2 is: " + result2);

                Console.ReadKey();

            } while (true);
        }
    }
}
