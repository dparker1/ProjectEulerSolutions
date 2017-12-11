using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProjectEulerProblems
{
    public class Problem065
    {
        public static int Solve()
        {
            int max = 100;
            BigInteger[] numerators = new BigInteger[max];
            numerators[0] = 2;
            numerators[1] = 3;
            int[] factors = new int[max];
            int f = 1;
            for(int i = 0; i < max - 3; i += 3)
            {
                factors[i] = 1;
                factors[i + 1] = 2 * f;
                factors[i + 2] = 1;
                f++;
            }
            for(int i = 1; i < max - 1; i++)
            {
                if(factors[i] == 1)
                {
                    numerators[i + 1] = numerators[i] + numerators[i - 1];
                }
                else
                {
                    numerators[i + 1] = numerators[i] * factors[i] + numerators[i - 1];
                }
            }


            return numerators[max - 1].ToString().Sum(x => int.Parse(x.ToString()));
        }
    }
}
