using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEulerProblems.Mathematics;

namespace ProjectEulerProblems
{
    public class Problem073
    {
        public static int Solve()
        {
            int count = 0;
            for(int d = 2; d <= 12000; d++)
            {
                for(int n = 1; n < d; n++)
                {
                    if(n * 2 >= d)
                    {
                        break;
                    }
                    if(n * 3 <= d)
                    {
                        continue;
                    }
                    if(EulerUtilities.GreatestCommonDivisor(n,d)==1)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
