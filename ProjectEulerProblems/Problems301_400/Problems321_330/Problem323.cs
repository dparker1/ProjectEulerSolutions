using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem323
    {
        //https://math.stackexchange.com/questions/26167/expectation-of-the-maximum-of-i-i-d-geometric-random-variables
        public static double Solve()
        {
            int n = 32;
            double p = 0.5, sum = 0;
            for(int k = 0; k <= 100; k++)
            {
                double f = 1 - Math.Pow(p, k);
                sum += 1 - Math.Pow(f, n);
            }
            return sum;
        }
    }
}
