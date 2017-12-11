using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem066
    {
        public static int Solve()
        {
            int maxD = 1;
            BigInteger maxX = 0;
            for(int D = 2; D <= 1000; D++)
            {
                if(EulerUtilities.IsWholeNumber(Math.Sqrt(D)))
                {
                    continue;
                }
                BigInteger upper = (int) Math.Sqrt(D);
                BigInteger m = 0;
                BigInteger d = 1;
                BigInteger a = upper;

                BigInteger initNumerator = 1;
                BigInteger numerator = a;

                BigInteger initDenominator = 0;
                BigInteger denominator = 1;

                while(numerator * numerator - D * denominator * denominator != 1)
                {
                    m = a * d - m;
                    d = (D - m * m) / d;
                    a = (upper + m) / d;

                    BigInteger num = initNumerator;
                    initNumerator = numerator;
                    BigInteger den = initDenominator;
                    initDenominator = denominator;

                    numerator = a * initNumerator + num;
                    denominator = a * initDenominator + den;
                }

                if(numerator > maxX)
                {
                    maxX = numerator;
                    maxD = D;
                }
            }
            return maxD;
        }
    }
}
