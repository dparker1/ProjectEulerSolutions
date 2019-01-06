using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem371
    {
        public static double Solve()
        {
            int M = 1000;
            double[] nums = new double[M + 1];
            nums[0] = 1;
            for(int k = 1; k <= M; k++)
            {
                nums[k] = (M - k) * nums[k - 1] / M;
            }

            return 1 + nums.Sum();
        }
    }
}
