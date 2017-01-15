using NCalc;
namespace IrrationalNumbers.Logic.ExpressionParser
{
    public class Parser
    {
        private int _wantedRemainder;

        public Parser()
        {
        }

        public void ConfigureParser(int remainder)
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

        }
    }
}
