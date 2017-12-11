using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProjectEulerProblems
{
    public class Problem053
    {
        public static long Solve()
        {
            BigInteger[][] pascals = EulerUtilities.GetBigPascalsTriangle(100);
            int count = 0;
            BigInteger oneMil = 1000000;
            for(int n = 23; n <= 100; n++)
            {
                for(int r = 1; r < n; r++)
                {
                    if(pascals[n][r] > oneMil)
                    {
                        count++;
                    }
                    else if(r > (n / 2))
                    {
                        break;
                    }
                }
            }
            return count;
        }
    }
}
