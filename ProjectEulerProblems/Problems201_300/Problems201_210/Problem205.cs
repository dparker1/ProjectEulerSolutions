using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem205
    {
        public static double Solve()
        {
            List<int> cubic = new List<int>(Dice(6, 6));
            List<int> pyramid = new List<int>(Dice(4, 9));
            cubic.Reverse();
            pyramid.Reverse();
            long ways = 0;
            for(int c = 0; c < cubic.Count - 1; c++)
            {
                for(int p = c + 1; p < pyramid.Count; p++)
                {
                    ways += cubic[c] * pyramid[p];
                }
            }
            return ways / (Math.Pow(6, 6) * Math.Pow(4, 9));
        }
        
        public static int[] Dice(int sides, int n)
        {
            int[] start = new int[sides];
            for(int i = 0; i < sides; i++)
            {
                start[i] = 1;
            }
            for(int i = 1; i < n; i++)
            {
                int[] next = new int[sides * (i + 1)];
                for(int j = 0; j < sides; j++)
                {
                    for(int k = 0; k < start.Length; k++)
                    {
                        next[j + k] += start[k];
                    }
                }
                start = next;
            }
            return start;
        }
    }
}
