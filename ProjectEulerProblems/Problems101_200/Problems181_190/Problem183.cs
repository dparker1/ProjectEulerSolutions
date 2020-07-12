using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem183
    {
        public static int Solve()
        {
            int limit = 10000;
            int sum = 0;
            for(int n = 5; n <= limit; n++)
            {
                int k = (int)Math.Round(n / Math.E);
                int nTemp = n;
                for(int f = 2; f <= k; f++)
                {
                    if(nTemp % f == 0 && k % f == 0)
                    {
                        nTemp /= f;
                        k /= f;
                        f = 2;
                    }
                }
                if(OnlyTwoFive(k))
                {
                    sum -= n;
                }
                else
                {
                    sum += n;
                }
            }
            return sum;
        }

        public static bool OnlyTwoFive(int n)
        {
            while(n > 1)
            {
                if(n % 2 == 0)
                {
                    n /= 2;
                }
                else if(n % 5 == 0)
                {
                    n /= 5;
                }
                else
                {
                    return false;
                }
            }
            return true;

        }
    }
}
