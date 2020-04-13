using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem351
    {
        public static long Solve()
        {
            long order = 100000000;
            long sum = order * (order + 1) / 2 - 1;
            EulerUtilities.LoadPrimesSmall((int)Math.Sqrt(order));
            for(int i = 2; i <= order; i++)
            {
                sum -= EulerUtilities.TotientCount(i);
            }

            return 6 * sum;
        }
    }
}
