using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProjectEulerProblems
{
    public class Problem686
    {
        public static int Solve()
        {
            double logTenTwo = Math.Log10(2);

            int i = 7;
            int d = 0;
            double diff = 0;
            int count = 0;
            double iLogTenTwo;
            while(count < 678910)
            {
                i++;
                iLogTenTwo =  i * logTenTwo;
                diff = iLogTenTwo - (int)iLogTenTwo;
                if(diff < logTenTwo)
                {
                    if(((int)Math.Pow(10, diff + 2)) == 123)
                    {
                        count++;
                    }
                }
            }

            return i;
        }
    }
}
