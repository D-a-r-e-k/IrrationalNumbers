using IrrationalNumbers.Core;
using IrrationalNumbers.Logic.Expansions;
using Mathos.Parser;
using NCalc;
namespace IrrationalNumbers.Logic.ExpressionParser
{
    public class Parser
    {
        private int _wantedRemainder;

        public Parser()
        {
        }

        private void ConfigureParser(int remainder)
        {
            _wantedRemainder = remainder;
        }

        public BigDecimal Estimate(string expression)
        {
            var exp = new Expression(expression);
            exp.EvaluateFunction += TomoAprasytosFunkcijos;
            exp.EvaluateFunction += DovydoAprasytosFunkcijos;

            return (BigDecimal) exp.Evaluate();

        }

        public void TomoAprasytosFunkcijos(string name, FunctionArgs args)
        {
            if (name == "SIN")
            {
                var parameter = args.Parameters[0].Evaluate();
                if (parameter is BigDecimal)
                {
                    args.Result = new SineTaylorExpansion().ExpandFunction(_wantedRemainder, (BigDecimal)parameter);
                }
                else
                {
                    args.Result = new SineTaylorExpansion().ExpandFunction(_wantedRemainder,
                        CoreUtils.PositiveStringToBig(args.Parameters[0].Evaluate().ToString()));
                }
            }
            else if (name == "COS")
            {
                var parameter = args.Parameters[0].Evaluate();
                if (parameter is BigDecimal)
                {
                    args.Result = new CosineTaylorExpansion().ExpandFunction(_wantedRemainder, (BigDecimal)parameter);
                }
                else
                {
                    args.Result = new CosineTaylorExpansion().ExpandFunction(_wantedRemainder,
                        CoreUtils.PositiveStringToBig(args.Parameters[0].Evaluate().ToString()));
                }
            }
            else if (name == "TAN")
            {
                var parameter = args.Parameters[0].Evaluate();
                if (parameter is BigDecimal)
                {
                    args.Result = new TangentTaylorExpansion().ExpandFunction(_wantedRemainder, (BigDecimal)parameter);
                }
                else
                {
                    args.Result = new TangentTaylorExpansion().ExpandFunction(_wantedRemainder,
                        CoreUtils.PositiveStringToBig(args.Parameters[0].Evaluate().ToString()));
                }
            }
            else if (name == "CTG")
            {
                var parameter = args.Parameters[0].Evaluate();
                if (parameter is BigDecimal)
                {
                    args.Result = new CotangentTaylorExpansion().ExpandFunction(_wantedRemainder, (BigDecimal)parameter);
                }
                else
                {
                    args.Result = new CotangentTaylorExpansion().ExpandFunction(_wantedRemainder,
                        CoreUtils.PositiveStringToBig(args.Parameters[0].Evaluate().ToString()));
                }
            }
            else if (name == "ARCSIN")
            {
                var parameter = args.Parameters[0].Evaluate();
                if (parameter is BigDecimal)
                {
                    args.Result = new ArcsineTaylorExpansion().ExpandFunction(_wantedRemainder, (BigDecimal)parameter);
                }
                else
                {
                    args.Result = new ArcsineTaylorExpansion().ExpandFunction(_wantedRemainder,
                        CoreUtils.PositiveStringToBig(args.Parameters[0].Evaluate().ToString()));
                }
            }
            else if (name == "ARCCOS")
            {
                var parameter = args.Parameters[0].Evaluate();
                if (parameter is BigDecimal)
                {
                    args.Result = new ArcsineTaylorExpansion().ExpandFunction(_wantedRemainder, (BigDecimal)parameter);
                }
                else
                {
                    args.Result = new ArcsineTaylorExpansion().ExpandFunction(_wantedRemainder,
                        CoreUtils.PositiveStringToBig(args.Parameters[0].Evaluate().ToString()));
                }
            }
            else if (name == "ARCCOT")
            {
                var parameter = args.Parameters[0].Evaluate();
                if (parameter is BigDecimal)
                {
                    args.Result = new ArccotangentTaylorExpansion().ExpandFunction(_wantedRemainder, (BigDecimal)parameter);
                }
                else
                {
                    args.Result = new ArccotangentTaylorExpansion().ExpandFunction(_wantedRemainder,
                        CoreUtils.PositiveStringToBig(args.Parameters[0].Evaluate().ToString()));
                }
            }
            else if (name == "ARCTAN")
            {
                var parameter = args.Parameters[0].Evaluate();
                if (parameter is BigDecimal)
                {
                    args.Result = new ArctangentTaylorExpansion().ExpandFunction(_wantedRemainder, (BigDecimal)parameter);
                }
                else
                {
                    args.Result = new ArctangentTaylorExpansion().ExpandFunction(_wantedRemainder,
                        CoreUtils.PositiveStringToBig(args.Parameters[0].Evaluate().ToString()));
                }
            }
            else if (name == "SINH")
            {
                var parameter = args.Parameters[0].Evaluate();
                if (parameter is BigDecimal)
                {
                    args.Result = new HyperbolicSineExpansion().ExpandFunction(_wantedRemainder, (BigDecimal)parameter);
                }
                else
                {
                    args.Result = new HyperbolicSineExpansion().ExpandFunction(_wantedRemainder,
                        CoreUtils.PositiveStringToBig(args.Parameters[0].Evaluate().ToString()));
                }
            }
            else if (name == "COSH")
            {
                var parameter = args.Parameters[0].Evaluate();
                if (parameter is BigDecimal)
                {
                    args.Result = new HyperbolicCosineExpansion().ExpandFunction(_wantedRemainder, (BigDecimal)parameter);
                }
                else
                {
                    args.Result = new HyperbolicCosineExpansion().ExpandFunction(_wantedRemainder,
                        CoreUtils.PositiveStringToBig(args.Parameters[0].Evaluate().ToString()));
                }
            }
            else if (name == "SQRT")
            {
                var parameter = args.Parameters[0].Evaluate();
                if (parameter is BigDecimal)
                {
                    args.Result = new BinomicalMaclaurinExpansion(1/2d, (BigDecimal) parameter).ExpandFunction(_wantedRemainder, (BigDecimal)parameter);
                }
                else
                {
                    args.Result = new BinomicalMaclaurinExpansion(1 / 2d, CoreUtils.PositiveStringToBig(args.Parameters[0].Evaluate().ToString())).ExpandFunction(_wantedRemainder,
                        CoreUtils.PositiveStringToBig(args.Parameters[0].Evaluate().ToString()));
                }
            }

        }

        public void DovydoAprasytosFunkcijos(string name, FunctionArgs args)
        {

        }
    }
}
