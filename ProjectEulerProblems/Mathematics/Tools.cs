using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/*
* Sourced from https://codereview.stackexchange.com/questions/95681/rational-number-implementation
*/
namespace ProjectEulerProblems.Mathematics
{
    public static class Tools
    {
        public static BigInteger LeastCommonMultiple(this BigInteger number1, BigInteger number2)
        {
            if(number1 == 0) return number2;
            if(number2 == 0) return number1;

            var positiveNumber2 = number2 < 0 ? BigInteger.Abs(number2) : number2;
            var positiveNumber1 = number1 < 0 ? BigInteger.Abs(number1) : number1;

            return positiveNumber1 / GreatestCommonDivisor(positiveNumber1, positiveNumber2) * positiveNumber2;
        }

        public static BigInteger GreatestCommonDivisor(this BigInteger number1, BigInteger number2)
        {
            var positiveNumber2 = number2 < 0 ? BigInteger.Abs(number2) : number2;
            var positiveNumber1 = number1 < 0 ? BigInteger.Abs(number1) : number1;

            if(positiveNumber1 == positiveNumber2)
                return positiveNumber1;

            if(positiveNumber1 == 0)
                return positiveNumber2;

            if(positiveNumber2 == 0)
                return positiveNumber1;

            if((~positiveNumber1 & 1) != 0)
                if((positiveNumber2 & 1) != 0)
                    return GreatestCommonDivisor(positiveNumber1 >> 1, positiveNumber2);
                else
                    return GreatestCommonDivisor(positiveNumber1 >> 1, positiveNumber2 >> 1) << 1;

            if((~positiveNumber2 & 1) != 0)
                return GreatestCommonDivisor(positiveNumber1, positiveNumber2 >> 1);

            if(positiveNumber1 > positiveNumber2)
                return GreatestCommonDivisor((positiveNumber1 - positiveNumber2) >> 1, positiveNumber2);

            return GreatestCommonDivisor((positiveNumber2 - positiveNumber1) >> 1, positiveNumber1);
        }
    }
}
