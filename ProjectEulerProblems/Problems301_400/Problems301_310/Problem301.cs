using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem301
    {
        public static int Solve()
        {
            int count = 0;
            for(int n = 1; n <= 1 << 30; n++)
            {
                if((n ^ (2*n) ^ (3*n)) == 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
