using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem078
    {
        public static int Solve()
        {
            List<int> ways = new List<int>();
            ways.Add(1);

            for(int n = 1; n < int.MaxValue; n++)
            {
                ways.Add(0);
                int i = 0;
                int p = 1;
                int sign = 0;

                while(p <= n)
                {
                    if(sign > 1)
                    {
                        ways[n] -= ways[n - p];
                    }
                    else
                    {
                        ways[n] += ways[n - p];
                    }
                    ways[n] %= 1000000;
                    sign = (sign + 1) % 4; 
                    i++;

                    int pn = (i / 2 + 1) * (i % 2 == 0 ? 1 : -1);
                    p = pn * (3 * pn - 1) / 2; 
                }
                if(ways[n] == 0)
                {
                    return n;
                }
            }
            return -1;
        }
    }
}
