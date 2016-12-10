
using System;

namespace IrrationalNumbers.Logic
{
    public class CosTaylorExpansion : IBasicFunctionExpansion
    {

        private double CalculateHigherOrderDerivative(int n)
        {
            if (n == 1)
                return -1;

            return 0.0f;
        }

        public int EvaluateRemainder(int wantedRemainder)
        {



            return 0;
        }

        public double ExpandCosFunction(int n)
        {



            return 0.0;
        }

        public double ExpandFunction(int wantedRemainder, double x)
        {
            throw new NotImplementedException();
        }
    }
}
