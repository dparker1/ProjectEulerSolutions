using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem064
    {
        public static int Solve()
        {
            int count = 0;
            for(int i = 2; i < 10000; i++)
            {
                if(!EulerUtilities.IsNthPower(i, 2) && GetPeriod(i) % 2 == 1)
                {
                    count++;
                }
            }
            return count;
        }

        private static int GetPeriod(int n)
        {
            double sqrt = Math.Sqrt(n);
            int i = 0, j = 1, i_start = -1, j_start = -1;
            for(int k = 0; k < int.MaxValue; k++)
            {
                j = (n - (i * i)) / j;
                i = -(i - (((int)sqrt + i) / j) * j);
                if(i == i_start && j == j_start)
                {
                    return k - 1;
                }
                if(k == 1)
                {
                    i_start = i;
                    j_start = j;
                }
            }
            return 0;
        }
    }
}
