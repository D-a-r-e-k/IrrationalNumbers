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
                    args.Result = new BinomicalMaclaurinExpansion((BigDecimal)power).ExpandFunction(_wantedRemainder, (BigDecimal)pow_value);
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
            else if (name == "PI")
            {
                var parameter = args.Parameters[0].Evaluate();
                if (parameter is BigDecimal)
                {
                    args.Result = new PiTaylorExpansion().ExpandFunction(_wantedRemainder, (BigDecimal)parameter);
                }
                else
                {
                    args.Result = new PiTaylorExpansion().ExpandFunction(_wantedRemainder,
                        CoreUtils.PositiveStringToBig(parameter.ToString()));
                }
            }
            else if (name == "SQRT")
            {
                var parameter = args.Parameters[0].Evaluate();
                if (parameter is BigDecimal)
                {
                    args.Result = new BinomicalMaclaurinExpansion(1 / 2).ExpandFunction(_wantedRemainder, (BigDecimal)parameter);
                }
                else
                {
                    args.Result = new BinomicalMaclaurinExpansion(1 / 2).ExpandFunction(_wantedRemainder,
                        CoreUtils.PositiveStringToBig(parameter.ToString()));
                }
            }
        }
    }
}
