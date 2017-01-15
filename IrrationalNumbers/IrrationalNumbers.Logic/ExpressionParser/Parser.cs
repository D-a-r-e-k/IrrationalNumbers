using Mathos.Parser;
using NCalc;
namespace IrrationalNumbers.Logic.ExpressionParser
{
    public class Parser
    {
        private readonly MathParser _parser;

        public Parser()
        {
            _parser = new MathParser();

            ConfigureParser();
        }

        private void ConfigureParser()
        {
            //_parser.LocalFunctions.Add("CustomFn", decimals => decimals[0] + 1);
           // _parser.LocalFunctions.Add("Custom", decimals => decimals[0] + 1);
           // _parser.LocalFunctions.Add("SuperCustom", decimals => decimals[0] + 1);
           //_parser.LocalFunctions["sin"] = 
            //parser.LocalFunctions["sin"] = new SineTaylorExpansion().ExpandFunction()
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
