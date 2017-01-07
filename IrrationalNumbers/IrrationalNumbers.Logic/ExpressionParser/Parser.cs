using Mathos.Parser;

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
    }
}
