using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem027
    {
        //b has to be prime and positive for n^2 + a*n + b to give a positive prime for n=0
        public static int Solve()
        {
            long[] bValues = EulerUtilities.GeneratePrimes(1000).ToArray();
            int maxStreak = 0;
            int aResult = 0, bResult = 0;

            for(int a = -999; a < 0; a+=2)
            {
                for(int b = bValues.Length - 1; b >= 0; b--)
                {
                    int n = 0, streak = 0, num;
                    num = Math.Abs(n * n + a * n + (int) bValues[b]);
                    while(EulerUtilities.IsPrime(num))
                    {
                        n++;
                        streak++;
                        num = Math.Abs(n * n + a * n + (int)bValues[b]);
                    }
                    
                    if(streak > maxStreak)
                    {
                        aResult = a;
                        bResult = (int) bValues[b];
                        maxStreak = streak;
                    }
                }
            }
            Console.WriteLine(aResult + ", " + bResult);
            return aResult * bResult;
        }
    }
}
