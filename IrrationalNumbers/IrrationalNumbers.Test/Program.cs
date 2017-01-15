using System;
using IrrationalNumbers.Logic.ExpressionParser;

namespace IrrationalNumbers.Test
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Expressions estimation program");
            Console.WriteLine("------------------------------");

            var parser = new ExpressionParser();

            do
            {
                try
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

                    parser.ConfigureParser((-1) * remainderParsed);

                    Console.WriteLine("Result: " + parser.Estimate(expressionToBeEstimated));
                }
                catch (Exception)
                {
                    Console.WriteLine("Possibly not supported signature of a function was provided. Please check examples at 'Naudotojo vadovas' document.");
                }
            } while (true);
        }
    }
}
