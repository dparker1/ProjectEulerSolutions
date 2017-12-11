using System;

namespace ProjectEulerProblems
{
    public class Problem003
    {
        public static Int64 Solve(Int64 testNumber)
        {
            Int64 largestFactor = 0;
            for(Int64 i = 2; i <= Math.Sqrt(testNumber); i++)
            {
                if(testNumber % i == 0 && EulerUtilities.IsPrime(i))
                {
                    largestFactor = i;
                }
            }
            return largestFactor;
        }

    }
}
