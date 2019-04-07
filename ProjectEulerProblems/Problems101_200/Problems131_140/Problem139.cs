using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem139
    {
        public static int Solve()
        {
            int limit = 100000000;
            int count = 0;
            bool mEven = true;
            for(int m = 2; m <= (int)((Math.Sqrt(1 + 2 * limit) - 1)/2); m++)
            {
                int n = mEven ? 1 : 2;
                mEven = !mEven;
                int m2 = m * m;
                int mn = 2 * m * n;
                while(n < m && (2*m2 + mn) <= limit)
                {
                    if(EulerUtilities.GreatestCommonDivisor(n, m) == 1)
                    {
                        int a = mn;
                        int b = m2 - n * n;
                        int c = m2 + n * n;
                        if(c % (b - a) == 0)
                        {
                            count += (limit / (a + b + c));
                        }
                    }
                    n += 2;
                    mn = 2 * m * n;
                }
            }
            return count;
        }
    }
}
