using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem179
    {
        public static int Solve()
        {
            int limit = 10000000;
            int[] divisorCounts = new int[limit];
            for(int i = 2; i < limit; i++)
            {
                for(int j = i; j < limit; j += i)
                {
                    divisorCounts[j]++;
                }
            }
            int c = 0;
            for(int i = 2; i < divisorCounts.Length - 1; i++)
            {
                if(divisorCounts[i] == divisorCounts[i + 1])
                {
                    c++;
                }
            }
            return c;
        }
    }
}
