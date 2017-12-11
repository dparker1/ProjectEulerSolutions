using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    class Problem007
    {
        public static long Solve(int prime)
        {
            int count = 2;
            long nthPrime = 0;
            for(long number = 3; number < int.MaxValue && count <= prime; number += 2)
            {
                if(EulerUtilities.IsPrime(number))
                {
                    count++;
                    nthPrime = number;
                }
            }
            return nthPrime;
        }
    }
}
