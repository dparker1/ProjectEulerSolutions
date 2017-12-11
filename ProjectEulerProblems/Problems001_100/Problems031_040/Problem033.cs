using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem033
    {
        public static int Solve()
        {
            int resultDenom = 1, resultNumer = 1;
            int originalN, originalD, otherN = 0, otherD = 0;
            for(int d = 11; d < 100; d++)
            {
                for(int n = d - 1; n >= 11; n--)
                {
                    if(!(n % 10 == 0 || d % 10 == 0))
                    {
                        originalN = n;
                        originalD = d;
                        if((n % 10) == (d % 10))
                        {
                            otherN = n / 10;
                            otherD = d / 10;
                        }
                        else if((n / 10) == (d % 10))
                        {
                            otherN = n % 10;
                            otherD = d / 10;
                        }
                        else if((n % 10) == (d / 10))
                        {
                            otherN = n / 10;
                            otherD = d % 10;
                        }
                        else if((n / 10) == (d / 10))
                        {
                            otherN = n % 10;
                            otherD = d % 10;
                        }
                        else
                        {
                            continue;
                        }

                        if((1.0 * originalN/originalD) == (1.0 * otherN / otherD))
                        {
                            resultDenom *= otherD;
                            resultNumer *= otherN;
                        }
                    }
                }
            }

            resultDenom /= EulerUtilities.GreatestCommonDivisor(resultNumer, resultDenom);
            return resultDenom;
        }
    }
}
