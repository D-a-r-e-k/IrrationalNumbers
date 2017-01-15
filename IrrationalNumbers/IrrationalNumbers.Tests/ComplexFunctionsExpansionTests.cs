using System;
using System.Numerics;
using IrrationalNumbers.Logic.ExpressionParser;
using NUnit.Framework;

namespace IrrationalNumbers.Tests
{
    [TestFixture]
    public class ComplexFunctionsExpansionTests
    {
        [Test]
        [TestCase("SIN(SIN(2.2))", -10)]
        public void ComplexFunction_TwoSinesComposition_ResultDoesNotExceedGivenRemainder(string expressionString, int remainder)
        {
            var parser = new Parser();

            parser.ConfigureParser(remainder);

            var actualResult = parser.Estimate(expressionString);
            var expectedResult = Math.Sin(Math.Sin(2.2));

            Assert.That(BigDecimal.Abs(actualResult - expectedResult) < Math.Pow(10, remainder));
        }

        [Test]
        [TestCase("SIN(2) + COS(3)", -10)]
        public void ComplexFunction_SumOfTwoFunctions_ResultDoesNotExceedGivenRemainder(string expressionString, int remainder)
        {
            var parser = new Parser();

            parser.ConfigureParser(remainder);

            var actualResult = parser.Estimate(expressionString);
            var expectedResult = Math.Sin(2) + Math.Cos(3);

            Assert.That(BigDecimal.Abs(actualResult - expectedResult) < Math.Pow(10, remainder));
        }

        [Test]
        [TestCase("SQRT(5) - SIN(2)", -10)]
        public void ComplexFunction_Subtraction_ResultDoesNotExceedGivenRemainder(string expressionString, int remainder)
        {
            var parser = new Parser();

            parser.ConfigureParser(remainder-1);

            var actualResult = parser.Estimate(expressionString);
            var expectedResult = Math.Sqrt(5) - Math.Sin(2);

            Assert.That(BigDecimal.Abs(actualResult - expectedResult) < Math.Pow(10, remainder));
        }

        [Test]
        [TestCase("5*SIN(7)", -10)]
        public void ComplexFunction_Multiplication_ResultDoesNotExceedGivenRemainder(string expressionString, int remainder)
        {
            var parser = new Parser();

            parser.ConfigureParser(remainder);

            var actualResult = parser.Estimate(expressionString);
            var expectedResult = 5*Math.Sin(7);

            Assert.That(BigDecimal.Abs(actualResult - expectedResult) < Math.Pow(10, remainder));
        }

        [Test]
        [TestCase("SINH(0.5) / ARCCOT(0.3)", -10)]
        public void ComplexFunction_Division_ResultDoesNotExceedGivenRemainder(string expressionString, int remainder)
        {
            var parser = new Parser();

            parser.ConfigureParser(remainder);

            var actualResult = parser.Estimate(expressionString);
            var expectedResult = Math.Sinh(0.5)/Math.Atan(1/0.3);

            Assert.That(BigDecimal.Abs(actualResult - expectedResult) < Math.Pow(10, remainder));
        }

        [Test]
        [TestCase("SIN(COS(0.5) * SIN(0.3)) + SINH(0.2)", -100,
            "0457781948121772847994020054489694244722289061763648855462307667324187406737329624864517378998434620430723552718174782796239716845410301349486227087882361188127754925265991971764678971365690343480091211405211045913314541710190", -225)]
        [TestCase("SIN(COS(0.5) * SIN(0.3)) + SIN(0.2)", -100,
            "04551152763757400758278644385977666221180009486781102750510054902308094072779254126713097593454972522472050138908613107786028993468151759532244794649762383371361191479782182337749660550517925569574280745748080258920203224067750", -226)]
        public void ComplexFunction_BiggerCases_ResultDoesNotExceedGivenRemainder(string expressionString, int remainder, string mantissa, int exponent)
        {
            var parser = new Parser();

            parser.ConfigureParser(remainder);

            var actualResult = parser.Estimate(expressionString);

            BigInteger mantissaBigInteger = BigInteger.Parse(mantissa);
            var expectedResult = new BigDecimal(mantissaBigInteger, exponent);

            Assert.That(BigDecimal.Abs(actualResult - expectedResult) < BigDecimal.PowBig(10, remainder));
        }
    }
}
