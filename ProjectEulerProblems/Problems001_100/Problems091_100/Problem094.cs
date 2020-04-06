using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem094
    {
        public static long Solve()
        {
            long sum = 0;
            long limit = 1000000000L;
            int k = 2;
            long n = (int)(((2 + Math.Sqrt(3)) * Math.Pow(7 - 4 * Math.Sqrt(3), k) +
                    (2 - Math.Sqrt(3)) * Math.Pow(7 + 4 * Math.Sqrt(3), k) - 1) / 3);
            do
            {
                sum += 3 * n - 1;
                k++;
                n = (int)(((2 + Math.Sqrt(3)) * Math.Pow(7 - 4 * Math.Sqrt(3), k) +
                    (2 - Math.Sqrt(3)) * Math.Pow(7 + 4 * Math.Sqrt(3), k) - 1) / 3);
            } while(3 * n - 1 <= limit);

            k = 1;
            n = (int)((1 + Math.Pow(7 - 4 * Math.Sqrt(3), k) + Math.Pow(7 + 4 * Math.Sqrt(3), k)) / 3);
            do
            {
                sum += 3 * n + 1;
                k++;
                n = (int)((1 + Math.Pow(7 - 4 * Math.Sqrt(3), k) + Math.Pow(7 + 4 * Math.Sqrt(3), k)) / 3) + 1;
            } while(3 * n + 1 <= limit);
            return sum;
        }
    }
}
