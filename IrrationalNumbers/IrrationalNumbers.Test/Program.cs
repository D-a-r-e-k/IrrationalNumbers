using IrrationalNumbers.Logic.Expansions;
using System;
using System.Diagnostics;
using System.Linq;
using Ciloci.Flee;
using IrrationalNumbers.Logic;
using Mathos.Parser;
using NCalc;

namespace IrrationalNumbers.Test
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Wnter wanted reminder: ");
            var remainderString = Console.ReadLine();

            int reminder;

            int.TryParse(remainderString, out reminder);


            Expression e = new Expression("SecretOperation(SIN(2), COS(6))");
            e.EvaluateFunction += delegate (string name, FunctionArgs arguments)
            {
                if (name == "SecretOperation")
                {
                    var evaluatedFirst = arguments.Parameters[0].Evaluate();
                    var evaluatedSecond = arguments.Parameters[1].Evaluate();

                    arguments.Result = (BigDecimal) evaluatedFirst + (BigDecimal) evaluatedSecond;
                }
                else if (name == "SIN")
                {
                    var parameter = arguments.Parameters[0].Evaluate();
                    if (parameter is BigDecimal)
                    {
                        arguments.Result = new SineTaylorExpansion().ExpandFunction(reminder, (BigDecimal) parameter);
                    }
                    else
                    {
                        arguments.Result = new SineTaylorExpansion().ExpandFunction(reminder,
                            Utils.PositiveStringToBig(arguments.Parameters[0].Evaluate().ToString()));
                    }
                }
                else if (name == "COS")
                {
                    var parameter = arguments.Parameters[0].Evaluate();
                    if (parameter is BigDecimal)
                    {
                        arguments.Result = new CosineTaylorExpansion().ExpandFunction(reminder, (BigDecimal) parameter);
                    }
                    else
                    {
                        arguments.Result = new CosineTaylorExpansion().ExpandFunction(reminder,
                            Utils.PositiveStringToBig(arguments.Parameters[0].Evaluate().ToString()));
                    }
                }
            };
            var result = (BigDecimal)e.Evaluate();

            Debug.Assert((BigDecimal.Abs(Math.Sin(2) + Math.Cos(6) - result)) <BigDecimal.PowBig(10, reminder) );

            //var b = new Expression("Sin(Cos(0))");
            //Console.WriteLine(b.Evaluate());            
            //Debug.Assert(9 == e.Evaluate());

            //ExpressionContext context = new ExpressionContext();
            //context.Imports.AddType(typeof(TestFunctions));
            //context.Variables.Add("a", 100);
            //context.Variables.Add("b", 200);


            //IDynamicExpression e = context.CompileDynamic("My('12170060.1217006012170060121700601217006012170060121700601217006012170060',34554354)");
            //int result = (int)e.Evaluate();
            //Console.WriteLine(result);

            //do
            //{
            //    Console.Write("Please type expression for estimation (exit - to exit the program): ");
            //    string expressionToBeEstimated = Console.ReadLine();

            //    if (expressionToBeEstimated == "exit")
            //        break;

            //    if (string.IsNullOrEmpty(expressionToBeEstimated))
            //    {
            //        Console.WriteLine("Type valid expression");
            //        continue;
            //    }

            //    Console.Write("Please type acceptable error (in format 1 / 10^x where x should be provided): ");
            //    var remainder = Console.ReadLine();
            //    int remainderParsed;
            //    if (!int.TryParse(remainder, out remainderParsed))
            //        Console.WriteLine("Acceptable error was provided not in correct format.");

            //    var parser = new MathParser();



            //    var result = parser.Parse("sin(1)");

            //    var result2 = parser.Parse("CustomFn(Custom(SuperCustom(1)))");

            //    Console.WriteLine("Result 1 is: " + result);
            //    Console.WriteLine("Result 2 is: " + result2);

            //    Console.ReadKey();

            //} while (true);
        }
    }
}
