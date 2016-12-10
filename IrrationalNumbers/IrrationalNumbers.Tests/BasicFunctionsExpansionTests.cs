
using System;
using System.Numerics;
using IrrationalNumbers.Core;
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

            Assert.That(BigFloat.Abs(expansion.ExpandFunction(wantedRemainder, x) - Math.Exp(x)) <
                        Math.Pow(10, wantedRemainder));
        }


        public void CosExpansion_RemainderGiven_ResultDoesNotExceedRemainder(int wantedRemainder, double x)
        {
            //IBasicFunctionExpansion expansion = new CosTaylorExpansion();

            //Assert.That(Math.Abs(expansion.ExpandFunction(wantedRemainder, x) - Math.Cos(x)) <
            //            Math.Pow(10, wantedRemainder));
        }
    }
}
