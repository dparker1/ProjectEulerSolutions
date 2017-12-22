using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem145
    {
        public static int Solve()
        {
            int count = 0;
            int bound = 1000000000;
            for(int i = 11; i < bound; i+=2)
            {
                if(IsReversible(i))
                {
                    count += 2;
                }

            }
            return count;
        }

        public static bool IsReversible(int n)
        {
            int initial = n;
            long reversed = 0;
            while(initial > 0)
            {
                reversed = 10 * reversed + initial % 10;
                initial /= 10;
            }
            long result = reversed + n;

            while(result != 0)
            {
                if((result % 10) % 2 == 0)
                {
                    return false;
                }
                result /= 10;
            }
            return true;
        }
    }
}
