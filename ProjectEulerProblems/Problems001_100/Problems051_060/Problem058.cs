using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem058
    {
        public static int Solve()
        {
            int number = 9;
            int delta = 2;
            double primeDiag = 3;
            while(primeDiag / (2*delta+1) > 0.1)
            {
                delta += 2;
                for(int i = 0; i < 3; i++)
                {
                    number += delta;
                    if(EulerUtilities.IsPrime(number))
                    {
                        primeDiag++;
                    }
                }
                number += delta;
                Console.WriteLine(delta);
            }
            return delta + 1;
        }
    }
}
