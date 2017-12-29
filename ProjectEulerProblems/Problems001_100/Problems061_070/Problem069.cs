using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem069
    {
        public static int Solve()
        {
            int totientMax = 0;
            double ratioMax = 0;
            for(int i = 10; i <= 1000000; i+=10)
            {
                if(i % 13 == 0 && i % 17 == 0 && i % 3 == 0 && i % 7 == 0 && i % 11 == 0)
                {
                    double ratio = (double)i / EulerUtilities.Totient(i).Count;
                    if(ratio > ratioMax)
                    {
                        ratioMax = ratio;
                        totientMax = i;
                    }
                }
                Console.WriteLine(i);
            }
            return totientMax;
        }
    }
}
