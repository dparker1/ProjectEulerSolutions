using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEulerProblems.Mathematics;

namespace ProjectEulerProblems
{
    public class Problem071
    {
        public static string Solve()
        {
            long lowerN = 1, lowerD = 3, currN = 1, currD = 3;

            for(long d = 2; d <= 1000000; d++)
            {
                for(long n = lowerN; n < d; n++)
                {
                    if(n * 7 >= d * 3)
                    {
                        break;
                    }
                    if(n * lowerD < d * lowerN)
                    {
                        continue;
                    }
                    currN = n;
                    currD = d;
                }
                lowerN = currN;
                lowerD = currD;
            }
            return lowerN + "/" + lowerD;
        }
    }
}
