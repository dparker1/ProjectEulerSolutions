using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem047
    {
        public static int Solve()
        {
            EulerUtilities.LoadPrimes(int.MaxValue / 10);
            HashSet<long> uniques;
            int streak = 0, answer = 0;
            for(int i = 646; i < int.MaxValue; i++)
            {
                uniques = EulerUtilities.UniquePrimeFactors((long)i);
                if(uniques.Count == 4)
                {
                    streak++;
                    if(streak == 4)
                    {
                        answer = i - 3;
                        break;
                    }
                }
                else
                {
                    streak = 0;
                }
            }
            return answer;
        }
    }
}
