using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem063
    {
        public static int Solve()
        {
            int count = 0;
            for(int pBase = 0; pBase < 10; pBase++)
            {
                for(int pPow = 1; pPow < 10000; pPow++)
                {
                    long num = (long) Math.Pow(pBase, pPow);
                    if(num.ToString().Length == pPow)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
