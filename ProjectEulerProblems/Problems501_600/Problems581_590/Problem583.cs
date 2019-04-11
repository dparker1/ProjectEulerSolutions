using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem583
    {
        public static int Solve()
        {
            int limit = (int)Math.Pow(10, 4);
            int sum = 0;

            bool mEven = true;
            for(int m = 2; m <= limit; m++)
            {
                int n = mEven ? 1 : 2;
                mEven = !mEven;
                int m2 = m * m;
                int mn = 2 * m * n;
                while(n < m && (2 * m2 + mn) <= limit)
                {
                    if(EulerUtilities.GreatestCommonDivisor(n, m) == 1)
                    {
                        int a = mn;
                        int b = m2 - n * n;
                        int c = m2 + n * n;
                        if(c % (b - a) == 0)
                        {
                            sum += (limit / (a + b + c));
                        }
                    }
                    n += 2;
                    mn = 2 * m * n;
                }
            }
            return sum;
        }
    }
}
