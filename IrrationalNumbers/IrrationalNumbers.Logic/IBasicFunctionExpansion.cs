﻿
namespace IrrationalNumbers.Logic
{
    public interface IBasicFunctionExpansion
    {
        BigDecimal ExpandFunction(int wantedRemainder, BigDecimal x);
    }
}
