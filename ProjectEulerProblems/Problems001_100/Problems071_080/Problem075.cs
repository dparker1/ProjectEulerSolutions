using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem075
    {
        public static int Solve()
        {
            int Lmax = 1500000;
            int[] counts = new int[Lmax + 1];
            for(int i = 2; i < Math.Sqrt(Lmax / 2); i++)
            {
                for(int j = 1; j < i; j++)
                {
                    if((i + j) % 2 == 1 && EulerUtilities.GreatestCommonDivisor(i, j) == 1)
                    {
                        int a = (int)(Math.Pow(i, 2) - Math.Pow(j, 2));
                        int b = 2 * i * j;
                        int c = (int)(Math.Pow(i, 2) + Math.Pow(j, 2));
                        int L = a + b + c;
                        for(int k = 1; k * L < Lmax; k++)
                        {
                            counts[k * L] += 1;
                        }
                    }
                }
            }

            return counts.Where(x => x == 1).Count();
        }
    }
}
