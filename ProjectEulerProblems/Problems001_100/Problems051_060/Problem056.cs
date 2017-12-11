using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProjectEulerProblems
{
    public class Problem056
    {
        public static int Solve()
        {
            BigInteger a, result;
            int maxSum = 0, sum;
            for(a = 1; a < 100; a++)
            {
                for(int b = 50; b < 100; b++)
                {
                    result = BigInteger.Pow(a, b);
                    sum = result.ToString().Sum(x => x - 48);
                    if(sum > maxSum)
                    {
                        maxSum = sum;
                    }
                }
            }
            return maxSum;
        }
    }
}
