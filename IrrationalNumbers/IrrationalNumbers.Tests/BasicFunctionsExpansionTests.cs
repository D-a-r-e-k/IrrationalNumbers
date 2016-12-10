
using System;
using IrrationalNumbers.Logic;
using IrrationalNumbers.Logic.Expansions;
using NUnit.Framework;

namespace IrrationalNumbers.Tests
{
    [TestFixture]
    public class BasicFunctionsExpansionTests
    {
        [Test]
        [TestCase(-4, 3)]
        [TestCase(-6,-2)]
        [TestCase(-10, 2.2)]
        [TestCase(-100, 2)]
        public void ExponentExpansion_RemainderGiven_ResultDoesNotExceedRemainder(int wantedRemainder, double x)
        {
            IBasicFunctionExpansion expansion = new ExponentTaylorExpansion();

            Assert.That(Math.Abs(expansion.ExpandFunction(wantedRemainder, x) - Math.Exp(x)) < Math.Pow(10, wantedRemainder));
        }
    }
}
