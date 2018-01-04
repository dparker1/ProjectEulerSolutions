using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem095
    {
        public static int Solve()
        {
            int min = 0, maxLength = 0;
            HashSet<int> badNumbers = new HashSet<int>();
            for(int start = 2; start <= 100000; start++)
            {
                List<int> chain = new List<int>();
                List<int> factors = EulerUtilities.FindProperDivisors(start);
                int current = factors.Sum();
                while(current > 1 && current <= 1000000)
                {
                    chain.Add(current);
                    factors = EulerUtilities.FindProperDivisors(current);
                    current = factors.Sum();
                    if(badNumbers.Contains(current))
                    {
                        break;
                    }
                    if(chain.Count > maxLength && chain.Contains(start))
                    {
                        maxLength = chain.Count;
                        min = chain.Min();
                        break;
                    }
                    if(chain.Contains(current))
                    {
                        badNumbers.Add(start);
                        break;
                    }
                }
            }
            return min;
        }
    }
}
