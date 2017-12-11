using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem043
    {
        public static long Solve()
        {
            long sum = 0;
            List<string> pandigitals = EulerUtilities.Permute("0123456789");
            int[] primes = new int[] { 1, 2, 3, 5, 7, 11, 13, 17 };
            int subNumber;
            bool success;
            foreach(string pan in pandigitals)
            {
                if(pan[0].Equals("0"))
                {
                    continue;
                }
                success = true;
                for(int i = 0; i < pan.Length - 2; i++)
                {
                    subNumber = int.Parse(pan.Substring(i, 3));
                    if((subNumber % primes[i]) != 0)
                    {
                        success = false;
                        break;
                    }
                }
                if(success)
                {
                    Console.WriteLine(pan);
                    sum += long.Parse(pan);
                }
            }
            return sum;
        }
    }
}
