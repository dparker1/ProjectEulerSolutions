using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem076
    {
        public static int Solve()
        {
            int[] ways = new int[101];
            ways[0] = 1;

            for(int back = 1; back < 100; back++)
            {
                for(int front = back; front < ways.Length; front++)
                {
                    ways[front] += ways[front - back];
                }
            }
            return ways[100];
        }

    }
}
