using System;
using System.Numerics;

namespace IrrationalNumbers.Core
{
    public class CoreUtils
    {
        public static char Delimiter { get; set; } = '.';
        public static char Negative { get; set; } = '-';

        public static BigDecimal PositiveStringToBig(string par)
        {
            if (IsInt(par))
            {
                return new BigDecimal(BigInteger.Parse(par), 0);
            }

            var splited = par.Split(Delimiter);

            if (splited.Length > 2)
            {
                throw new Exception(); //TODO: Create custom ex
            }
            BigDecimal big;

            if (splited[0].ToCharArray()[0] == '0')
            {
                if (splited.Length > 2)
                {
                    throw new Exception();
                }

                big = new BigDecimal(BigInteger.Parse(splited[1]), splited[1].Length);
            }
            else
            {
                var mantisa = splited[0] + splited[1];

                big = new BigDecimal(BigInteger.Parse(mantisa), -splited[1].Length);
            }

            return big;
        }

        //public static BigDecimal StringToBig(string par)
        //{
        //    if (par[0] == Negative)
        //    {
        //        var big = PositiveStringToBig(par.Replace(Negative.ToString(), string.Empty));
        //        big. = -1;
        //    }
        //}

        private static bool IsInt(string par)
        {
            return !par.Contains(Delimiter.ToString());
        }
    }
}