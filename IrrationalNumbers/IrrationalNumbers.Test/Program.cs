using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IrrationalNumbers.Logic.ExpressionParser;

namespace IrrationalNumbers.Test
{
    class Program
    {
        private const double NotSetVariable = -1000000000;

        private static void Main(string[] args)
        {
            Console.WriteLine("Expressions estimation program");
            Console.WriteLine("------------------------------");

            var parser = new ExpressionParser();

            do
            {
                try
                {
                    Console.WriteLine();
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

                    parser.ConfigureParser((-1)*remainderParsed);

                    BigDecimal estimatedResult = NotSetVariable;
                    var task = Task.Run(() =>
                    {
                        estimatedResult = parser.Estimate(expressionToBeEstimated);
                    });

                    var whenExecute = WhenAllEx(new List<Task> {task},
                        secondsPassed =>
                        {
                            Console.Clear();
                            Console.WriteLine($"Processing... Already passed {secondsPassed} s");
                        });

                    whenExecute.Wait();

                    if (estimatedResult == NotSetVariable)
                        Console.WriteLine("Try one more time. Look for examples at 'Naudotojo vadovas'.");
                    else
                    {
                        Console.WriteLine($"Expression: {expressionToBeEstimated}");
                        Console.WriteLine("Result: " + estimatedResult);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Possibly not supported signature of a function was provided. Please check examples at 'Naudotojo vadovas' document.");
                }
            } while (true);
        }

        public static async Task WhenAllEx(ICollection<Task> tasks, Action<int> reportProgressAction)
        {
            var whenAllTask = Task.WhenAll(tasks);

            int secondsPassed = 0;
            for (;;)
            {
                var timer = Task.Delay(1000);
                secondsPassed++;

                await Task.WhenAny(whenAllTask, timer);
                
                if (whenAllTask.IsCompleted)
                    return;

                reportProgressAction(secondsPassed);
            }
        }
    }
}
