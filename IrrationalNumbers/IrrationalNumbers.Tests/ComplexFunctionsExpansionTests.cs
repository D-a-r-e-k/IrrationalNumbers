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
            var parser = new ExpressionParser();

            parser.ConfigureParser(remainder);

            var actualResult = parser.Estimate(expressionString);
            var expectedResult = Math.Sin(Math.Sin(2.2));

            Assert.That(BigDecimal.Abs(actualResult - expectedResult) < Math.Pow(10, remainder));
        }

        [Test]
        [TestCase("SIN(2) + COS(3)", -10)]
        public void ComplexFunction_SumOfTwoFunctions_ResultDoesNotExceedGivenRemainder(string expressionString, int remainder)
        {
            var parser = new ExpressionParser();

            parser.ConfigureParser(remainder);

            var actualResult = parser.Estimate(expressionString);
            var expectedResult = Math.Sin(2) + Math.Cos(3);

            Assert.That(BigDecimal.Abs(actualResult - expectedResult) < Math.Pow(10, remainder));
        }

        [Test]
        [TestCase("SQRT(5) - SIN(2)", -10)]
        public void ComplexFunction_Subtraction_ResultDoesNotExceedGivenRemainder(string expressionString, int remainder)
        {
            var parser = new ExpressionParser();

            parser.ConfigureParser(remainder-1);

            var actualResult = parser.Estimate(expressionString);
            var expectedResult = Math.Sqrt(5) - Math.Sin(2);

            Assert.That(BigDecimal.Abs(actualResult - expectedResult) < Math.Pow(10, remainder));
        }

        [Test]
        [TestCase("5*SIN(7)", -10)]
        public void ComplexFunction_Multiplication_ResultDoesNotExceedGivenRemainder(string expressionString, int remainder)
        {
            var parser = new ExpressionParser();

            parser.ConfigureParser(remainder);

            var actualResult = parser.Estimate(expressionString);
            var expectedResult = 5*Math.Sin(7);

            Assert.That(BigDecimal.Abs(actualResult - expectedResult) < Math.Pow(10, remainder));
        }

        [Test]
        [TestCase("SINH(0.5) / ARCCOT(0.3)", -10)]
        public void ComplexFunction_Division_ResultDoesNotExceedGivenRemainder(string expressionString, int remainder)
        {
            var parser = new ExpressionParser();

            parser.ConfigureParser(remainder);

            var actualResult = parser.Estimate(expressionString);
            var expectedResult = Math.Sinh(0.5)/Math.Atan(1/0.3);

            Assert.That(BigDecimal.Abs(actualResult - expectedResult) < Math.Pow(10, remainder));
        }

        [Test]
        [TestCase("POW(2.2,9) * POW(2, 2.2) / POW(-2, 2) ", -10)]
        public void ComplexFunction_PowersDivision_ResultDoesNotExceedGivenRemainder(string expressionString, int remainder)
        {
            var parser = new ExpressionParser();

            parser.ConfigureParser(remainder);
            parser.ConfigureParser(remainder - 3);

            var actualResult = parser.Estimate(expressionString);
            var expectedResult = Math.Pow(2.2, 9)*Math.Pow(2, 2.2)/Math.Pow(-2, 2);

            Assert.That(BigDecimal.Abs(actualResult - expectedResult) < Math.Pow(10, remainder));
        }

        [Test]
        [TestCase("LN(2.1) * LG(23.2) / LOG(2,3)", -10)]
        public void ComplexFunction_LogarithmsUsed_ResultDoesNotExceedGivenRemainder(string expressionString, int remainder)
        {
            var parser = new ExpressionParser();

            parser.ConfigureParser(remainder);

            var actualResult = parser.Estimate(expressionString);
            var expectedResult = Math.Log(2.1, Math.E)*Math.Log10(23.2)/Math.Log(3, 2);

            Assert.That(BigDecimal.Abs(actualResult - expectedResult) < Math.Pow(10, remainder));
        }

        [Test]
        [TestCase("PI * LOG(2,3) + COS(PI)", -10)]
        public void ComplexFunction_PiUsed_ResultDoesNotExceedGivenRemainder(string expressionString, int remainder)
        {
            var parser = new ExpressionParser();

            parser.ConfigureParser(remainder);

            var actualResult = parser.Estimate(expressionString);
            var expectedResult = Math.PI * Math.Log(2, 3) + Math.Cos(Math.PI);

            Assert.That(BigDecimal.Abs(actualResult - expectedResult) < Math.Pow(10, remainder));
        }

        [Test]
        [TestCase("POW(PI,PI) * TAN(0.0005) + COTH(0.2)", -10)]
        public void ComplexFunction_PiAndPowTogether_ResultDoesNotExceedGivenRemainder(string expressionString, int remainder)
        {
            var parser = new ExpressionParser();

            parser.ConfigureParser(remainder);

            var actualResult = parser.Estimate(expressionString);
            var expectedResult = Math.Pow(Math.PI, Math.PI)*Math.Tan(0.0005);

            Assert.That(BigDecimal.Abs(actualResult - expectedResult) < Math.Pow(10, remainder));
        }

        [Test]
        [TestCase("SIN(COS(0.5) * SIN(0.3)) + SINH(0.2)", -100,
            "0457781948121772847994020054489694244722289061763648855462307667324187406737329624864517378998434620430723552718174782796239716845410301349486227087882361188127754925265991971764678971365690343480091211405211045913314541710190", -225)]
        [TestCase("SIN(COS(0.5) * SIN(0.3)) + SIN(0.2)", -100,
            "04551152763757400758278644385977666221180009486781102750510054902308094072779254126713097593454972522472050138908613107786028993468151759532244794649762383371361191479782182337749660550517925569574280745748080258920203224067750", -226)]
        
        // composition+summation+multiplication of 100 functions

        [TestCase("(SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2) + (SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2) + (SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2) + (SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2) + (SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2) + (SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2) + (SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2) + (SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2) + (SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2) + (SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2)", -2, "-4304740960033663798390102333371933248826824304807110711719302207247420241026340792882335523745673532654710600691275574464794633095381130843201943295020976790364541746648917285347883003959358447591590756176130846310601076050", -221)]
        [TestCase("(SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2) + (SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2) + (SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2) + (SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2) + (SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2) + (SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2) + (SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2) + (SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2) + (SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2) + (SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2)", -10, "-4304740960033663798390102333371933248826824304807110711719302207247420241026340792882335523745673532654710600691275574464794633095381130843201943295020976790364541746648917285347883003959358447591590756176130846310601076050", -221)]
        [TestCase("(SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2) +" + 
                  "(SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2) +" +
                  "(SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2) +" +
                  "(SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2) +" +
                  "(SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2) +" +
                  "(SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2) +" +
                  "(SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2) +" +
                  "(SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2) +" +
                  "(SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2) +" +
                  "(SIN(0.2) * ARCCOT(0.2) * (ARCTAN(2.2) + SIN(0.233))) / (SIN(0.23) * COS(0.2233) + SIN(COS(23.2))) + SIN(23.2) + COS(23.2)", 
            -100,
            "-4304740960033663798390102333371933248826824304807110711719302207247420241026340792882335523745673532654710600691275574464794633095381130843201943295020976790364541746648917285347883003959358447591590756176130846310601076050", -221)]

        // summation and subtraction of 100 functions

        [TestCase("SIN(2) - SIN(0.2) + 2 + SIN(2) + SIN(0.2) - 2 + COS(0.2)+ SIN(0.2) + 2 - SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(0.2) +" +
                  " + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2) + SIN(2) + SIN(0.2) " +
                  "+ 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2)" +
                  " + 2 + COS(0.2) + TAN(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(2) + SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 " +
                  "+ COS(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(0.2)" +
                  " + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(2) + SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) " +
                  "+ 2 + COS(0.2) + TAN(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)" +
                  "+ SIN(2) + SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(0.2) + 2 + SIN(2) +" +
                  " SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)", -2, "170669", -4)]
        [TestCase("SIN(2) - SIN(0.2) + 2 + SIN(2) + SIN(0.2) - 2 + COS(0.2)+ SIN(0.2) + 2 - SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(0.2) +" +
                  " + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2) + SIN(2) + SIN(0.2) " + 
                  "+ 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2)" +
                  " + 2 + COS(0.2) + TAN(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(2) + SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 " + 
                  "+ COS(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(0.2)" +
                  " + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(2) + SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) " + 
                  "+ 2 + COS(0.2) + TAN(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)" + 
                  "+ SIN(2) + SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(0.2) + 2 + SIN(2) +" + 
                  " SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)", -100, "170669", -4)]
        [TestCase("SIN(2) - SIN(0.2) + 2 + SIN(2) + SIN(0.2) - 2 + COS(0.2)+ SIN(0.2) + 2 - SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2) + SIN(2) + SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(2) + SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(2) + SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(2) + SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)+ SIN(0.2) + 2 + SIN(2) + SIN(0.2) + 2 + COS(0.2) + TAN(0.2)", -10, "170669", -4)]

        // joined use of various 10 functions - a^x, hyperbolic, trygonometric, LN
        [TestCase("POW(2.2, COSH(0.2) * SINH(-0.2) + SIN(0.2)) * LN(2) + LN(23) - COTH(2.2) + TANH(0.1) + LN(0.2) + SIN(0.1)", -10, "13901892787696875176958123749041900686179532341658416679392575857116024058416082744000027752958180993675115015216997782961089162436803789752083623462654032868837226904114986480767746931438543430193665232995607620382243989312651", -226)]
        [TestCase("POW(2.2, COSH(0.2) * SINH(-0.2) + SIN(0.2)) * LN(2) + LN(23) - COTH(2.2) + TANH(0.1) + LN(0.2) + SIN(0.1)", -60, "13901892787696875176958123749041900686179532341658416679392575857116024058416082744000027752958180993675115015216997782961089162436803789752083623462654032868837226904114986480767746931438543430193665232995607620382243989312651", -226)]
        public void ComplexFunction_BiggerCases_ResultDoesNotExceedGivenRemainder(string expressionString, int remainder, string mantissa, int exponent)
        {
            var parser = new ExpressionParser();

            parser.ConfigureParser(remainder - 5);

            var actualResult = parser.Estimate(expressionString);

            BigInteger mantissaBigInteger = BigInteger.Parse(mantissa);
            var expectedResult = new BigDecimal(mantissaBigInteger, exponent);

            Assert.That(BigDecimal.Abs(actualResult - expectedResult) < BigDecimal.PowBig(10, remainder));
        }

        [Test]
        [TestCase("PI", -10)]
        public void ComplexFunction_Pi_ResultDoesNotExceedGivenRemainder(string expressionString, int remainder)
        {
            var parser = new ExpressionParser();

            parser.ConfigureParser(remainder);

            var actualResult = parser.Estimate(expressionString);
            var expectedResult = Math.PI;

            Assert.That(BigDecimal.Abs(actualResult - expectedResult) < Math.Pow(10, remainder));
        }

        [Test]
        [TestCase("E", -10)]
        public void ComplexFunction_E_ResultDoesNotExceedGivenRemainder(string expressionString, int remainder)
        {
            var parser = new ExpressionParser();

            parser.ConfigureParser(remainder);

            var actualResult = parser.Estimate(expressionString);
            var expectedResult = Math.E;

            Assert.That(BigDecimal.Abs(actualResult - expectedResult) < Math.Pow(10, remainder));
        }

        [Test]
        [TestCase("TANH(E)", -10)]
        public void ComplexFunction_TANH_ResultDoesNotExceedGivenRemainder(string expressionString, int remainder)
        {
            var parser = new ExpressionParser();

            parser.ConfigureParser(remainder);

            var actualResult = parser.Estimate(expressionString);
            var expectedResult = Math.Tanh(Math.E);

            Assert.That(BigDecimal.Abs(actualResult - expectedResult) < Math.Pow(10, remainder));
        }

        [Test]
        [TestCase("COTH(E)", -10)]
        public void ComplexFunction_COTH_ResultDoesNotExceedGivenRemainder(string expressionString, int remainder)
        {
            var parser = new ExpressionParser();

            parser.ConfigureParser(remainder);

            var actualResult = parser.Estimate(expressionString);
            var expectedResult = (Math.Exp(Math.E) + Math.Exp(-Math.E)) / (Math.Exp(Math.E) - Math.Exp(-Math.E));

            Assert.That(BigDecimal.Abs(actualResult - expectedResult) < Math.Pow(10, remainder));
        }

        [Test]
        [TestCase("LOG(2, E)", -10)]
        public void ComplexFunction_LOG_ResultDoesNotExceedGivenRemainder(string expressionString, int remainder)
        {
            var parser = new ExpressionParser();

            parser.ConfigureParser(remainder);

            var actualResult = parser.Estimate(expressionString);
            var expectedResult = Math.Log(2, Math.E);

            Assert.That(BigDecimal.Abs(actualResult - expectedResult) < Math.Pow(10, remainder));
        }

        [Test]
        [TestCase("LG(PI)", -10)]
        public void ComplexFunction_LG_ResultDoesNotExceedGivenRemainder(string expressionString, int remainder)
        {
            var parser = new ExpressionParser();

            parser.ConfigureParser(remainder);

            var actualResult = parser.Estimate(expressionString);
            var expectedResult = Math.Log10(Math.PI);

            Assert.That(BigDecimal.Abs(actualResult - expectedResult) < Math.Pow(10, remainder));
        }

        [Test]
        [TestCase("LN(PI/2 + E)", -10)]
        public void ComplexFunction_LN_ResultDoesNotExceedGivenRemainder(string expressionString, int remainder)
        {
            var parser = new ExpressionParser();

            parser.ConfigureParser(remainder);

            var actualResult = parser.Estimate(expressionString);
            var expectedResult = Math.Log(Math.PI/2 + Math.E, Math.E);

            Assert.That(BigDecimal.Abs(actualResult - expectedResult) < Math.Pow(10, remainder));
        }
        [Test]
        [TestCase("POW(E, POW(SIN(1.5), 2))", -10)]
        public void ComplexFunction_POW_ResultDoesNotExceedGivenRemainder(string expressionString, int remainder)
        {
            var parser = new ExpressionParser();

            parser.ConfigureParser(remainder);

            var actualResult = parser.Estimate(expressionString);
            var expectedResult = Math.Pow(Math.E, Math.Pow(Math.Sin(1.5), 2));

            Assert.That(BigDecimal.Abs(actualResult - expectedResult) < Math.Pow(10, remainder));
        }
        [Test]
        [TestCase("EXP(POW(SIN(7), 2))", -10)]
        public void ComplexFunction_EXP_ResultDoesNotExceedGivenRemainder(string expressionString, int remainder)
        {
            var parser = new ExpressionParser();

            parser.ConfigureParser(remainder);

            var actualResult = parser.Estimate(expressionString);
            var expectedResult = Math.Pow(Math.E, Math.Pow(Math.Sin(7), 2));

            Assert.That(BigDecimal.Abs(actualResult - expectedResult) < Math.Pow(10, remainder));
        }
    }
}
