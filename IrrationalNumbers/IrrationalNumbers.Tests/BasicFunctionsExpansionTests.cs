using System;
using System.Numerics;
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
        
        public void ExponentExpansion_SmallerCases_ResultDoesNotExceedGivenRemainder(int wantedRemainder, double x)
        {
            IBasicFunctionExpansion expansion = new ExponentTaylorExpansion();

            Assert.That(BigDecimal.Abs(expansion.ExpandFunction(wantedRemainder, x) - Math.Exp(x)) <
                        BigDecimal.PowBig(10, wantedRemainder));
        }

        [TestCase(-18, 30.13, "121700605711171678432846158992696306528185160679894168070747367852014136882826354841064320509428521949331157221881022476106008477062066555476735553879197079643920981936555143598804079043438581829725830847658201927646716631198098409026688231424866249400459126302534628255908502502057786593307978775817400767624408215878100153941671469564488110033003092966994013780710465655298727820493958097111136945793784260244452064344030580617964394109607731601738", -436)]
        [TestCase(-100, 2, "73890560989306502272304274605750078131803155705518473240871278225225737960790577633843124850791217947737531612654788661238846036927812733744783922133980777749001228956074107537023913309475506820865818202696478682084042209822552348757424625414146799281293318880707633010193378997407299869600953033075153208188236846947930299135587714456831239232727646025883399964612128492852096789051388246639871228137268610647356263792951822278429484345861352876938669857", -454)]
        public void ExponentExpansion_BiggerCases_ResultDoesNotExceedGivenRemainder(int wantedRemainder, double x, string mantissa, int exponent)
        {
            IBasicFunctionExpansion expansion = new ExponentTaylorExpansion();

            BigInteger mantissaBigInteger = BigInteger.Parse(mantissa);
            var expectedAnswer = new BigDecimal(mantissaBigInteger, exponent);

            Assert.That(BigDecimal.Abs(expansion.ExpandFunction(wantedRemainder, x) - expectedAnswer) <
                        BigDecimal.PowBig(10, wantedRemainder));
        }


        public void CosExpansion_RemainderGiven_ResultDoesNotExceedRemainder(int wantedRemainder, double x)
        {
            //IBasicFunctionExpansion expansion = new CosTaylorExpansion();

            //Assert.That(Math.Abs(expansion.ExpandFunction(wantedRemainder, x) - Math.Cos(x)) <
            //            Math.Pow(10, wantedRemainder));
        }
    }
}
