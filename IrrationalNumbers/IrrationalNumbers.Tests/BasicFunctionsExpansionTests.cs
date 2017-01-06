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

        // (x)^alpha

       [Test]
       [TestCase(-12, 7, 0.5)]
       [TestCase(-10, 1.5325, 1/3d)]
       [TestCase(-10, 5, 1 / 3d)]

        public void BinomicalExpansion_ResultDoesNotExceedGivenRemainder(int wantedRemainder, double x, double alpha)
        {
            IBasicFunctionExpansion expansion = new BinomicalMaclaurinExpansion(alpha, x);

            var expectedAnswer = Math.Pow(x,alpha);

            var answer = expansion.ExpandFunction(wantedRemainder - 1, x);

            Assert.That(BigDecimal.Abs(answer - expectedAnswer) <
                        BigDecimal.PowBig(10, wantedRemainder));
        }

        

        [Test]
        [TestCase(-97, 7, 0.5d, "264575131106459059050161575363926042571025918308245018036833445920106882323028362776039288647454361", -98)]
        //[TestCase(-100, 2, "10373147207275480958778097647678207116623912692491946035699817338445187575192564330668133815772665086843487323876994489760693526504445981561333042115804699343375852664379146597293287070471644501324038728366521090056064455419389775115609300562338133640494712991862376811503450739216970299399434472802027383401789583133145676184198699961549634507263255850226407021189688993308848314433966906548831003619962145169201943850330075384604033004009102811197955069", -454)]
        public void Binomial_BiggerCases_ResultDoesNotExceedGivenRemainder(int wantedRemainder, double x, double alpha, string mantissa, int exponent)
        {
            IBasicFunctionExpansion expansion = new BinomicalMaclaurinExpansion(alpha, x);

            BigInteger mantissaBigInteger = BigInteger.Parse(mantissa);
            var expectedAnswer = new BigDecimal(mantissaBigInteger, exponent);

            var result = expansion.ExpandFunction(wantedRemainder - 2, x);

            Assert.That(BigDecimal.Abs(result - expectedAnswer) <
                        BigDecimal.PowBig(10, wantedRemainder));
        }

        // cos(x)

        [Test]
        [TestCase(-4, 3)]
        [TestCase(-6, -2)]
        [TestCase(-10, 2.2)]
        public void CosineExpansion_SmallerCases_ResultDoesNotExceedGivenRemainder(int wantedRemainder, double x)
        {
            IBasicFunctionExpansion expansion = new CosineTaylorExpansion();

            var expectedAnswer = Math.Cos(x);

            Assert.That(BigDecimal.Abs(expansion.ExpandFunction(wantedRemainder, x) - expectedAnswer) <
                        BigDecimal.PowBig(10, wantedRemainder));
        }

        [Test]
        [TestCase(-60, 17, "-0275163338051596922220342656551862898596973688298596247753093776293238002659315593011297790450826030423348946965030952890732597213692355119314036778396099956400567381815209850082787850418057450690691761418933028290735420999", -222)]
        [TestCase(-100, 2, "-0416146836547142386997568229500762189766000771075544890755149973781964936124079169074531777860169140367366791365215728559288656399891172385683442074019964695321532618247978386250585148546251586628021039179201508829008648012", -222)]
        public void CosineExpansion_BiggerCases_ResultDoesNotExceedGivenRemainder(int wantedRemainder, double x, string mantissa, int exponent)
        {
            IBasicFunctionExpansion expansion = new CosineTaylorExpansion();

            BigInteger mantissaBigInteger = BigInteger.Parse(mantissa);
            var expectedAnswer = new BigDecimal(mantissaBigInteger, exponent);

            Assert.That(BigDecimal.Abs(expansion.ExpandFunction(wantedRemainder, x) - expectedAnswer) <
                        BigDecimal.PowBig(10, wantedRemainder));
        }

        // ln(x)

        [Test]
        [TestCase(-4, 1)]
        [TestCase(-6, 4)]
        [TestCase(-10, 2.2)]
        public void NaturalLogarithmExpansion_SmallerCases_ResultDoesNotExceedGivenRemainder(int wantedRemainder, double x)
        {
            IBasicFunctionExpansion expansion = new NaturalLogarithmExpansion();

            var expectedAnswer = Math.Log(x, Math.E);
            var actualAnswer = expansion.ExpandFunction(wantedRemainder, x);

            Assert.That(BigDecimal.Abs(actualAnswer - expectedAnswer) <
                        BigDecimal.PowBig(10, wantedRemainder));
        }

        [Test]
        [TestCase(-100, 30.13, "34055213531422098669201939336109935963480873422234707618889750306553843667667027816737199427377733853389068629235544877121147178088828868449616500527881809364123725263155542108001842477734974091439046646439450096553362007479686", -226)]
        [TestCase(-30, 8, "20794415416798359282516963643745297042265004030807657623620400284801808659090841468175899809892560626260044430617120572010565607072743916710980122549052278857921827124851143055709211158716750204133700503460934938657173614255180", -226)]
        public void NaturalLogarithmExpansion_BiggerCases_ResultDoesNotExceedGivenRemainder(int wantedRemainder, double x, string mantissa, int exponent)
        {
            IBasicFunctionExpansion expansion = new NaturalLogarithmExpansion();

            BigInteger mantissaBigInteger = BigInteger.Parse(mantissa);
            var expectedAnswer = new BigDecimal(mantissaBigInteger, exponent);
            var actualAnswer = expansion.ExpandFunction(wantedRemainder, x);

            Assert.That(BigDecimal.Abs(actualAnswer - expectedAnswer) <
                        BigDecimal.PowBig(10, wantedRemainder));
        }

        // log(x)

        [Test]
        [TestCase(-4, 1, 2)]
        [TestCase(-6, 4, 8)]
        [TestCase(-10, 2.2, 10.1)]
        public void LogarithmExpansion_SmallerCases_ResultDoesNotExceedGivenRemainder(int wantedRemainder, double x, double logBase)
        {
            IBasicFunctionExpansion expansion = new LogarithmExpansion(logBase);

            var expectedAnswer = Math.Log(x, logBase);
            var actualAnswer = expansion.ExpandFunction(wantedRemainder, x);

            Assert.That(BigDecimal.Abs(actualAnswer - expectedAnswer) <
                        BigDecimal.PowBig(10, wantedRemainder));
        }

        [Test]
        [TestCase(-100, 30.13, 4, "24565643839098692277855520446699519478212670024205625182277228395120156440347897729660158177498673823756267998075667961880286413701863203567284077852295371249469236475460902514636914739526960013445212825451947471393416064299965", -226)]
        [TestCase(-50, 1, 3, "0", 0)]
        public void LogarithmExpansion_BiggerCases_ResultDoesNotExceedGivenRemainder(int wantedRemainder, double x, double logBase, string mantissa, int exponent)
        {
            IBasicFunctionExpansion expansion = new LogarithmExpansion(logBase);

            BigInteger mantissaBigInteger = BigInteger.Parse(mantissa);
            var expectedAnswer = new BigDecimal(mantissaBigInteger, exponent);
            var actualAnswer = expansion.ExpandFunction(wantedRemainder, x);

            Assert.That(BigDecimal.Abs(actualAnswer - expectedAnswer) <
                        BigDecimal.PowBig(10, wantedRemainder));
        }

        // a^x

        [Test]
        [TestCase(-4, 1, 2)]
        [TestCase(-6, 4, 8)]
        [TestCase(-10, 2.2, 10.1)]
        //[TestCase(-5, -2/3d, -3/8d)]

        public void ExponentWithAnyPowerExpansion_SmallerCases_ResultDoesNotExceedGivenRemainder(int wantedRemainder, double x, double logBase)
        {
            IBasicFunctionExpansion expansion = new ExponentialWithAnyBaseExpansion(logBase);

            var expectedAnswer = Math.Pow(logBase, x);
            var actualAnswer = expansion.ExpandFunction(wantedRemainder, x);

            Assert.That(BigDecimal.Abs(actualAnswer - expectedAnswer) <
                        BigDecimal.PowBig(10, wantedRemainder));
        }

        // sin(x)

        [Test]
        [TestCase(-4, 3)]
        [TestCase(-6, -2)]
        [TestCase(-10, 2.2)]
        public void SineExpansion_SmallerCases_ResultDoesNotExceedGivenRemainder(int wantedRemainder, double x)
        {
            IBasicFunctionExpansion expansion = new SineTaylorExpansion();

            var expectedAnswer = Math.Sin(x);

            Assert.That(BigDecimal.Abs(expansion.ExpandFunction(wantedRemainder, x) - expectedAnswer) <
                        BigDecimal.PowBig(10, wantedRemainder));
        }

        [Test]
        [TestCase(-18, 30.13, "959698253781593846470427416180744164538901729509732716871391762087594571076727460270418789177558702039852106738627349764351546280336893300918643829350335333963610463315042724930807882203711661678430778315952474006196880320", -223)]
        [TestCase(-100, 2, "9092974268256816953960198659117448427022549714478902683789730115309673015407835446201266889249593803099678967423994862612809531086753281202700203397467737828483793101969669977498435704751651754809873424551688486626659939784205856048352873765246", -245)]
        public void SineExpansion_BiggerCases_ResultDoesNotExceedGivenRemainder(int wantedRemainder, double x, string mantissa, int exponent)
        {
            IBasicFunctionExpansion expansion = new SineTaylorExpansion();

            BigInteger mantissaBigInteger = BigInteger.Parse(mantissa);
            var expectedAnswer = new BigDecimal(mantissaBigInteger, exponent);
            //var expectedAnswer = Math.Cos(x);
            var exp = expansion.ExpandFunction(wantedRemainder, x);
            Assert.That(BigDecimal.Abs(expansion.ExpandFunction(wantedRemainder, x) - expectedAnswer) <
                        BigDecimal.PowBig(10, wantedRemainder));
        }

        // tan(x)

        [Test]
        [TestCase(-4, 3)]
        [TestCase(-6, -2)]
        [TestCase(-10, 2.2)]
        public void TangentExpansion_SmallerCases_ResultDoesNotExceedGivenRemainder(int wantedRemainder, double x)
        {
            IBasicFunctionExpansion expansion = new TangentTaylorExpansion();

            var expectedAnswer = Math.Tan(x);

            Assert.That(BigDecimal.Abs(expansion.ExpandFunction(wantedRemainder, x) - expectedAnswer) <
                        BigDecimal.PowBig(10, wantedRemainder));
        }

        [Test]
        [TestCase(-18, 30.13, "-3414901409331961967288131016272162864918670845439864625568133758124621897711786330175912711762729292302436272401044011949137347993177599694730114703047906416154103254666972603581833232732865656845785796468217933471477453600", -223)]
        [TestCase(-100, 2, "-2185039863261518991643306102313682543432017746227663164562955869966773747209194182319743542104728547594898517449807496540068863845805593421142506295657769579867859253503660240556971073247890135105173560048263674060711975065", -223)]
        public void TangentExpansion_BiggerCases_ResultDoesNotExceedGivenRemainder(int wantedRemainder, double x, string mantissa, int exponent)
        {

            IBasicFunctionExpansion expansion = new TangentTaylorExpansion();

            BigInteger mantissaBigInteger = BigInteger.Parse(mantissa);
            var expectedAnswer = new BigDecimal(mantissaBigInteger, exponent);
            //var expectedAnswer = Math.Cos(x);
            var exp = expansion.ExpandFunction(wantedRemainder, x);
            Assert.That(BigDecimal.Abs(expansion.ExpandFunction(wantedRemainder, x) - expectedAnswer) <
                        BigDecimal.PowBig(10, wantedRemainder));
        }

        // ctg(x)

        [Test]
        [TestCase(-4, 3)]
        [TestCase(-6, -2)]
        [TestCase(-10, 2.2)]
        public void CotangentExpansion_SmallerCases_ResultDoesNotExceedGivenRemainder(int wantedRemainder, double x)
        {
            IBasicFunctionExpansion expansion = new CotangentTaylorExpansion();

            var actualAnswer = expansion.ExpandFunction(wantedRemainder, x);
            var expectedAnswer = Math.Cos(x)/Math.Sin(x);

            Assert.That(BigDecimal.Abs(actualAnswer - expectedAnswer) <
                        BigDecimal.PowBig(10, wantedRemainder));
        }

        [Test]
        [TestCase(-18, 30.13, "-0292834222758900790076561915982839848092607279025375136191702230955564834198215854942178678063696928827574431465278945054743209131325520348069383013202172197526684653657137886363411986561204034888736937531144659204610714114", -222)]
        [TestCase(-100, 2, "-0457657554360285763750277410432047276428486329231674329641392162636292270156281308678308522721023089573245377725638375437069992491593749803191141920724171205663842131820653988296256172032242872813208847431322465849762959970", -222)]
        public void CotangentExpansion_BiggerCases_ResultDoesNotExceedGivenRemainder(int wantedRemainder, double x, string mantissa, int exponent)
        {

            IBasicFunctionExpansion expansion = new CotangentTaylorExpansion();

            BigInteger mantissaBigInteger = BigInteger.Parse(mantissa);
            var expectedAnswer = new BigDecimal(mantissaBigInteger, exponent);
            //var expectedAnswer = Math.Cos(x);
            var exp = expansion.ExpandFunction(wantedRemainder, x);
            Assert.That(BigDecimal.Abs(expansion.ExpandFunction(wantedRemainder, x) - expectedAnswer) <
                        BigDecimal.PowBig(10, wantedRemainder));
        }

        // pi

        [Test]
        [TestCase(-16, 1)]
        [TestCase(-6, 1)]
        [TestCase(-10, 1)]
        public void PiExpansion_SmallerCases_ResultDoesNotExceedGivenRemainder(int wantedRemainder, double x)
        {
            IBasicFunctionExpansion expansion = new PiTaylorExpansion();

            var expectedAnswer = Math.PI;
            var result = expansion.ExpandFunction(wantedRemainder, x);
            Assert.That(BigDecimal.Abs(result - expectedAnswer) <
                        BigDecimal.PowBig(10, wantedRemainder));
        }

        // arctg(x)

        [Test]
        [TestCase(-4, 3)]
        [TestCase(-5, 1.01)]
        [TestCase(-6, -0.2)]
        [TestCase(-10, 0.2)]
        [TestCase(-6, -10)]
        [TestCase(-5, 0.95)]
        [TestCase(-4, 1)]
        public void ArctangentExpansion_SmallerCases_ResultDoesNotExceedGivenRemainder(int wantedRemainder, double x)
        {
            IBasicFunctionExpansion expansion = new ArctangentTaylorExpansion();

            var expectedAnswer = Math.Atan(x);
            
            Assert.That(BigDecimal.Abs(expansion.ExpandFunction(wantedRemainder, x) - expectedAnswer) <
                        BigDecimal.PowBig(10, wantedRemainder));
        }

        // arcsin(x)
        [Test]
        [TestCase(-4, 0)]
        [TestCase(-5, 1)]
        [TestCase(-6, -0.2)]
        [TestCase(-10, 0.2)]
        [TestCase(-6, -1)]
        [TestCase(-5, 0.98)]
        public void ArcSineExpansion_SmallerCases_ResultDoesNotExceedGivenRemainder(int wantedRemainder, double x)
        {
            IBasicFunctionExpansion expansion = new ArcsineTaylorExpansion();

            var expectedAnswer = Math.Asin(x);
            var actualAnswer = expansion.ExpandFunction(wantedRemainder, x);

            Assert.That(BigDecimal.Abs(actualAnswer - expectedAnswer) <
                        BigDecimal.PowBig(10, wantedRemainder));
        }

    }
}
