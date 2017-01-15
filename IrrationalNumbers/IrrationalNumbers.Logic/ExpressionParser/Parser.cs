using IrrationalNumbers.Core;
using IrrationalNumbers.Logic.Expansions;
using NCalc;


namespace IrrationalNumbers.Logic.ExpressionParser
{
    public class Parser
    {
        private int _wantedRemainder;

        public void ConfigureParser(int remainder)
        {
            _wantedRemainder = remainder;
        }

        public BigDecimal Estimate(string expression)
        {
            var exp = new Expression(expression);
            exp.EvaluateFunction += TomoAprasytosFunkcijos;
            exp.EvaluateFunction += DovydoAprasytosFunkcijos;
            ConfigureParser(exp);
            return (BigDecimal) exp.Evaluate();

        }

        public void ConfigureParser(Expression exp)
        {
            exp.Parameters["PI"] = new PiTaylorExpansion().ExpandFunction(_wantedRemainder, 1);
            exp.Parameters["E"] = new ExponentTaylorExpansion().ExpandFunction(_wantedRemainder, 1);
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
                    args.Result = new BinomicalMaclaurinExpansion(1/2d).ExpandFunction(_wantedRemainder, (BigDecimal)parameter);
                }
                else
                {
                    args.Result = new BinomicalMaclaurinExpansion(1 / 2d).ExpandFunction(_wantedRemainder,
                        CoreUtils.PositiveStringToBig(parameter.ToString()));
                }
            }

        }

        public void DovydoAprasytosFunkcijos(string name, FunctionArgs args)
        {
            if (name == "TANH")
            {
                var parameter = args.Parameters[0].Evaluate();
                if (parameter is BigDecimal)
                {
                    args.Result = new HyperbolicTangentExpansion().ExpandFunction(_wantedRemainder, (BigDecimal)parameter);
                }
                else
                {
                    args.Result = new HyperbolicTangentExpansion().ExpandFunction(_wantedRemainder,
                        CoreUtils.PositiveStringToBig(parameter.ToString()));
                }
            }
            else if (name == "COTH")
            {
                var parameter = args.Parameters[0].Evaluate();
                if (parameter is BigDecimal)
                {
                    args.Result = new HyperbolicCotangentExpansion().ExpandFunction(_wantedRemainder, (BigDecimal)parameter);
                }
                else
                {
                    args.Result = new HyperbolicCotangentExpansion().ExpandFunction(_wantedRemainder,
                        CoreUtils.PositiveStringToBig(parameter.ToString()));
                }
            }
            else if (name == "LOG")
            {
                var log_base = args.Parameters[0].Evaluate();
                var log_value = args.Parameters[1].Evaluate();
                if (log_base is BigDecimal && log_value is BigDecimal)
                {
                    args.Result = new LogarithmExpansion((BigDecimal)log_base).ExpandFunction(_wantedRemainder, (BigDecimal)log_value);
                }
                else if (log_base is BigDecimal)
                {
                    args.Result = new LogarithmExpansion((BigDecimal)log_base).ExpandFunction(_wantedRemainder,
                        CoreUtils.PositiveStringToBig(log_value.ToString()));
                }
                else if (log_value is BigDecimal)
                {
                    args.Result = new LogarithmExpansion(CoreUtils.PositiveStringToBig(log_base.ToString())).ExpandFunction(_wantedRemainder,
                        (BigDecimal)log_value);
                }
                else
                {
                    args.Result = new LogarithmExpansion(CoreUtils.PositiveStringToBig(log_base.ToString())).ExpandFunction(_wantedRemainder,
                        CoreUtils.PositiveStringToBig(log_value.ToString()));
                }
            }
            else if (name == "LG")
            {
                var parameter = args.Parameters[0].Evaluate();
                if (parameter is BigDecimal)
                {
                    args.Result = new LogarithmExpansion(10).ExpandFunction(_wantedRemainder, (BigDecimal)parameter);
                }
                else
                {
                    args.Result = new LogarithmExpansion(10).ExpandFunction(_wantedRemainder,
                        CoreUtils.PositiveStringToBig(parameter.ToString()));
                }
            }
            else if (name == "LN")
            {
                var parameter = args.Parameters[0].Evaluate();
                if (parameter is BigDecimal)
                {
                    args.Result = new NaturalLogarithmExpansion().ExpandFunction(_wantedRemainder, (BigDecimal)parameter);
                }
                else
                {
                    args.Result = new NaturalLogarithmExpansion().ExpandFunction(_wantedRemainder,
                        CoreUtils.PositiveStringToBig(parameter.ToString()));
                }
            }
            else if (name == "POW")
            {
                var pow_value = args.Parameters[0].Evaluate();
                var power = args.Parameters[1].Evaluate();
                if (power is BigDecimal && pow_value is BigDecimal)
                {
                    args.Result = new ExponentialWithAnyBaseExpansion((BigDecimal)pow_value).ExpandFunction(_wantedRemainder, (BigDecimal)power);
                }
                else if (power is BigDecimal)
                {
                    args.Result = new BinomicalMaclaurinExpansion((BigDecimal)power).ExpandFunction(_wantedRemainder,
                        CoreUtils.PositiveStringToBig(pow_value.ToString()));
                }
                else if (pow_value is BigDecimal)
                {
                    args.Result = new BinomicalMaclaurinExpansion(CoreUtils.PositiveStringToBig(power.ToString())).ExpandFunction(_wantedRemainder,
                        (BigDecimal)pow_value);
                }
                else
                {
                    args.Result = new BinomicalMaclaurinExpansion(CoreUtils.PositiveStringToBig(power.ToString())).ExpandFunction(_wantedRemainder,
                        CoreUtils.PositiveStringToBig(pow_value.ToString()));
                }
            }
            else if (name == "EXP")
            {
                var parameter = args.Parameters[0].Evaluate();
                if (parameter is BigDecimal)
                {
                    args.Result = new ExponentTaylorExpansion().ExpandFunction(_wantedRemainder, (BigDecimal)parameter);
                }
                else
                {
                    args.Result = new ExponentTaylorExpansion().ExpandFunction(_wantedRemainder,
                        CoreUtils.PositiveStringToBig(parameter.ToString()));
                }
            }
        }
    }
}
