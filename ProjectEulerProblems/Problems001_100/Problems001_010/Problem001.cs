using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem001
    {
        public static int Solve()
        {
            int sum = 0;
            for(int i = 1; i < 1000; i++)
            {
                if((i % 3 == 0) || (i % 5 == 0))
                {
                    sum += i;
                }
            }
            return sum;
        }
    }
}
