using System.Numerics;
using IrrationalNumbers.Core;

namespace IrrationalNumbers.Logic.Expansions
{
    public class SquareRootTaylorExpansion: IBasicFunctionExpansion
    {
        private BigFloat FinalMultiplier { get; set; } = 1;
       
            public BigFloat ExpandFunction(int wantedRemainder, double x)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        ///Metodas, kuris pavercia bet koki saknies parametra i israiska 1 + x. 
        ///Pvz : 100 = (1 + 1/3) * 75
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private BigFloat NormalizeParameter(BigFloat parameter)
        {
            var half = parameter/2;
            var quarter = parameter/4;

            var divideBy = half + quarter;

            var divisionResult = parameter/divideBy;
            FinalMultiplier = divideBy;

            return divisionResult - 1;
        }
    }
}