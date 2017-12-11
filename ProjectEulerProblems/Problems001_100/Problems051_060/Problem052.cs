using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class Problem052
    {
        public static int Solve()
        {
            int numberLength = 3, answer = -1;
            while(answer == -1)
            {
                answer = TryWithNumberLength(numberLength++);
            }
            return answer;
        }

        public static int TryWithNumberLength(int length)
        {
            int min = (int)Math.Pow(10, length - 1);
            int max = 2 * min;
            List<string> permutations;
            for(int i = min; i <= max; i++)
            {
                permutations = EulerUtilities.Permute(i.ToString());
                if(permutations.Contains((i * 2).ToString()) && permutations.Contains((i * 3).ToString()) && permutations.Contains((i * 4).ToString())
                    && permutations.Contains((i * 5).ToString()) && permutations.Contains((i * 6).ToString()))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
