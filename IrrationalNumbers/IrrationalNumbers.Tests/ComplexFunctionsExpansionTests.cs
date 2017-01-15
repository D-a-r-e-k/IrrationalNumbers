using IrrationalNumbers.Logic.ExpressionParser;
using NCalc;
using NUnit.Framework;

namespace IrrationalNumbers.Tests
{
    [TestFixture]
    public class ComplexFunctionsExpansionTests
    {

        [Test]
        [TestCase("SIN(SIN(2.2))", -2)]
        public void ComplexFunction_TwoSinesComposition_ResultDoesNotExceedGivenRemainder(string expressionString, int remainder)
        {
            var parser = new Parser();

            parser.Estimate(expressionString)

        }

    }
}
