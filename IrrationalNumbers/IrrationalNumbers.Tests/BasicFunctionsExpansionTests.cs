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
        // e^x

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

        // sinh(x)

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

        // cosh(x)

        [Test]
        [TestCase(-4, 3)]
        [TestCase(-6, -2)]
        [TestCase(-10, 2.2)]
        public void HyperbolicCosineExpansion_SmallerCases_ResultDoesNotExceedGivenRemainder(int wantedRemainder, double x)
        {
            IBasicFunctionExpansion expansion = new HyperbolicCosineExpansion();

            Assert.That(BigDecimal.Abs(expansion.ExpandFunction(wantedRemainder, x) - Math.Cosh(x)) <
                        BigDecimal.PowBig(10, wantedRemainder));
        }

        [Test]
        [TestCase(-18, 30.13, "608503028555858392164230799071924519248853557484051807154797859694862217101250801207118635009300079783394420229277184391048751482501376251698704067877744948967598693342891223704489924995618718894933959696360161197032398561292767116751283433572507815315148359959916421147857692999180069482576997948409086084420168281431063022523930123560744736975539668009155038861447866655221216643362962818014797174910058431348193621394708509706937352254669175079462", -437)]
        [TestCase(-100, 2, "37621956910836314595622134777737461082939735582307116027776433475883235850902727266607053037848894217644152242275562091681669752823370632063186436741973918902456865615830466680036148757616980333833089071765469465106377873662059392048691993132142902117117744733233913933652809353503194114555005104763989168063095324585837168821207313793188587910704041343253268444561825442318088803545070216647748619656321908314990066980942033063737751607760215906933616374845287277429209130621636612297399659680122942751464902152328190825129703116156647371352032123372805782655418962697324059264233681331629748921533459264880966902826613535352705223496224672240437992226226203669811405137846853607842366671562223488559349476210237111310568101070029567860121739016472661450916857869268487080051363466365982738426552345027063001870988612005453445415729957709216474285224218553961263635603051415349550737412466397766576229967078819", -910)]
        public void HyperbolicCosineExpansion_BiggerCases_ResultDoesNotExceedGivenRemainder(int wantedRemainder, double x, string mantissa, int exponent)
        {
            IBasicFunctionExpansion expansion = new HyperbolicCosineExpansion();

            BigInteger mantissaBigInteger = BigInteger.Parse(mantissa);
            var expectedAnswer = new BigDecimal(mantissaBigInteger, exponent);

            Assert.That(BigDecimal.Abs(expansion.ExpandFunction(wantedRemainder, x) - expectedAnswer) <
                        BigDecimal.PowBig(10, wantedRemainder));
        }

        // th(x)

        [Test]
        [TestCase(-4, 3)]
        [TestCase(-6, -2)]
        [TestCase(-10, 2.2)]
        public void HyperbolicTangentExpansion_SmallerCases_ResultDoesNotExceedGivenRemainder(int wantedRemainder, double x)
        {
            IBasicFunctionExpansion expansion = new HyperbolicTangentExpansion();

            Assert.That(BigDecimal.Abs(expansion.ExpandFunction(wantedRemainder, x) - Math.Tanh(x)) <
                        BigDecimal.PowBig(10, wantedRemainder));
        }

        [Test]
        [TestCase(-18, 30.13, "09999999999999999999999999864965569806337046152826919297377596775234996301672102603136262597151465360330881044128388120731063400702083160328247321285730053124613140432359688299746689345040331862727539258676474721986910369282596", -226)]
        [TestCase(-100, 2, "09640275800758168839464137241009231502550299762409347760482632174131079463176102025594748500452076891494616122189245966682730670219130203345474859564729146243367515945063168120072459506585620571969505507398350541318484357230711981318433390625862638297220062583674818792183059292972750839238032977002071723558480020850695385482001370172851524822716983977242742432258200945814770457633894600812455531950884944665881076531252828850835846141665088663772194245", -454)]
        public void HyperbolicTangentExpansion_BiggerCases_ResultDoesNotExceedGivenRemainder(int wantedRemainder, double x, string mantissa, int exponent)
        {
            IBasicFunctionExpansion expansion = new HyperbolicTangentExpansion();

            BigInteger mantissaBigInteger = BigInteger.Parse(mantissa);
            var expectedAnswer = new BigDecimal(mantissaBigInteger, exponent);

            Assert.That(BigDecimal.Abs(expansion.ExpandFunction(wantedRemainder, x) - expectedAnswer) <
                        BigDecimal.PowBig(10, wantedRemainder));
        }

        // cth(x)

        [Test]
        [TestCase(-4, 3)]
        [TestCase(-6, -2)]
        [TestCase(-10, 2.2)]
        public void HyperbolicCotangentExpansion_SmallerCases_ResultDoesNotExceedGivenRemainder(int wantedRemainder, double x)
        {
            IBasicFunctionExpansion expansion = new HyperbolicCotangentExpansion();

            var expectedAtanH = (Math.Exp(x) + Math.Exp(-x))/(Math.Exp(x) - Math.Exp(-x));

            Assert.That(BigDecimal.Abs(expansion.ExpandFunction(wantedRemainder, x) -  expectedAtanH) <
                        BigDecimal.PowBig(10, wantedRemainder));
        }

        [Test]
        [TestCase(-18, 30.13, "10000000000000000000000000135034430193662953847173082526052136997488324422726704105195466123989277211768247279885978721325291505599221444125070669261642216198136354960458555379844958304412720933670160096075632305959143067807791616446595503188968431120587943893844424000652065438047578930308584115495271106823036650883195850816596240011227138449929333446797045171707632551230904215593849305305286366782546364472006740076276943333723209548701832189500042235", -454)]
        [TestCase(-100, 2, "10373147207275480958778097647678207116623912692491946035699817338445187575192564330668133815772665086843487323876994489760693526504445981561333042115804699343375852664379146597293287070471644501324038728366521090056064455419389775115609300562338133640494712991862376811503450739216970299399434472802027383401789583133145676184198699961549634507263255850226407021189688993308848314433966906548831003619962145169201943850330075384604033004009102811197955069", -454)]
        public void HyperbolicCotangentExpansion_BiggerCases_ResultDoesNotExceedGivenRemainder(int wantedRemainder, double x, string mantissa, int exponent)
        {
            IBasicFunctionExpansion expansion = new HyperbolicCotangentExpansion();

            BigInteger mantissaBigInteger = BigInteger.Parse(mantissa);
            var expectedAnswer = new BigDecimal(mantissaBigInteger, exponent);

            Assert.That(BigDecimal.Abs(expansion.ExpandFunction(wantedRemainder, x) - expectedAnswer) <
                        BigDecimal.PowBig(10, wantedRemainder));
        }

        // cos(x)

        //public void CosExpansion_RemainderGiven_ResultDoesNotExceedRemainder(int wantedRemainder, double x)
        //{
        //IBasicFunctionExpansion expansion = new CosTaylorExpansion();

        //Assert.That(Math.Abs(expansion.ExpandFunction(wantedRemainder, x) - Math.Cos(x)) <
        //            Math.Pow(10, wantedRemainder));
        //}
    }
}
