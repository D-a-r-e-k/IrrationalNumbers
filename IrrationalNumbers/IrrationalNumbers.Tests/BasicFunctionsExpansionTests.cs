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
        
        [Test]
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

        [Test]
        [TestCase(-4, 3)]
        [TestCase(-6, -2)]
        [TestCase(-10, 2.2)]
        public void HyperbolicSineExpansion_SmallerCases_ResultDoesNotExceedGivenRemainder(int wantedRemainder, double x)
        {
            IBasicFunctionExpansion expansion = new HyperbolicSineExpansion();

            Assert.That(BigDecimal.Abs(expansion.ExpandFunction(wantedRemainder, x) - Math.Sinh(x)) <
                        BigDecimal.PowBig(10, wantedRemainder));
        }

        [Test]
        [TestCase(-18, 30.13, "608503028555858392164230790855038546032998049314889873552675818825279151727012747203524570084985139709917151989533040370011333288119289303068651470914225847471611126022660212283550865438767099402324348780221858079434767750", -209)]
        [TestCase(-100, 2, "36268604078470187676682139828012617048863420123211357213094844749342502109887850367236071812942323730093379370379226569557176284104442101681597485392006858846544363340243640856987764551858526487032729130931009216977664336160492956708732632282003897164175574147473719076540569643904105755045947928311164040125141522362093130314380400663642651322023604682630131520050303050534007985506318029992122608480946702332366196812009789214691732738101136970005053482", -454)]
        public void HyperbolicSineExpansion_BiggerCases_ResultDoesNotExceedGivenRemainder(int wantedRemainder, double x, string mantissa, int exponent)
        {
            IBasicFunctionExpansion expansion = new HyperbolicSineExpansion();

            BigInteger mantissaBigInteger = BigInteger.Parse(mantissa);
            var expectedAnswer = new BigDecimal(mantissaBigInteger, exponent);

            Assert.That(BigDecimal.Abs(expansion.ExpandFunction(wantedRemainder, x) - expectedAnswer) <
                        BigDecimal.PowBig(10, wantedRemainder));
        }

        //public void CosExpansion_RemainderGiven_ResultDoesNotExceedRemainder(int wantedRemainder, double x)
        //{
        //IBasicFunctionExpansion expansion = new CosTaylorExpansion();

        //Assert.That(Math.Abs(expansion.ExpandFunction(wantedRemainder, x) - Math.Cos(x)) <
        //            Math.Pow(10, wantedRemainder));
        //}
    }
}
