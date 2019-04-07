using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem291
    {
        public static int Solve()
        {
            long p = 0;
            long n = 1;
            int count = 0;
            long limit = 5 * (long)Math.Pow(10, 15);
            while(p < limit)
            {
                if(EulerUtilities.IsPrime(p))
                {
                    count++;
                }
                p = 2 * n * (n - 1) + 1;
                n++;
            }
            Console.WriteLine(p);
            return count;
        }
    }
}
